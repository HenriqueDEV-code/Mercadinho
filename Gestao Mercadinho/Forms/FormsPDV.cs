using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Gestao_Mercadinho.Model;


/// <summary>
///  Mini sistema de PDV para simbolisar um sistema de Decrementro de quantidade no estoque
/// </summary>

namespace Gestao_Mercadinho.Forms
{
    public partial class PDV : Form
    {
        // Lista para armazenar os itens da venda atual
        private List<ItemVenda> itensVenda = new List<ItemVenda>();
        // Total da venda atual
        private decimal totalVenda = 0;

        public PDV()
        {
            InitializeComponent();
            ConfigurarPDV();

            // Configurar atalhos de teclado
            this.KeyPreview = true;
            this.KeyDown += PDV_KeyDown;
        }

        private void ConfigurarPDV()
        {
            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar eventos
            TB_Codigo_Produto.KeyDown += TB_Codigo_Produto_KeyDown!;
            TB_Quantidade.KeyDown += TB_Quantidade_KeyDown!;
            TB_PrecoUnit.KeyDown += TB_PrecoUnit_KeyDown!;
            btnFinalizarVenda.Click += BtnFinalizarVenda_Click!;
            btnCancelarVenda.Click += BtnCancelarVenda_Click!;

            // Configurar valores padrão
            TB_Quantidade.Text = "1";
            TB_Volume.Text = "0";
            TB_Subtotal.Text = "R$ 0,00";

            // Focar no campo de código
            TB_Codigo_Produto.Focus();
        }


        // Configurar DataGridView para exibir os itens da venda
        private void ConfigurarDataGridView()
        {
            DGV_PDV.AutoGenerateColumns = false;
            DGV_PDV.AllowUserToAddRows = false;
            DGV_PDV.AllowUserToDeleteRows = false;
            DGV_PDV.ReadOnly = true;
            DGV_PDV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_PDV.MultiSelect = false;
            DGV_PDV.RowHeadersVisible = false;

            // Configurar colunas
            DGV_PDV.Columns.Clear();
            DGV_PDV.Columns.Add("Codigo", "Código");
            DGV_PDV.Columns.Add("Nome", "Produto");
            DGV_PDV.Columns.Add("Quantidade", "Qtd");
            DGV_PDV.Columns.Add("PrecoUnitario", "Preço Unit.");
            DGV_PDV.Columns.Add("TotalItem", "Total");

            // Configurar larguras
            DGV_PDV.Columns["Codigo"]!.Width = 80;
            DGV_PDV.Columns["Nome"]!.Width = 200;
            DGV_PDV.Columns["Quantidade"]!.Width = 60;
            DGV_PDV.Columns["PrecoUnitario"]!.Width = 100;
            DGV_PDV.Columns["TotalItem"]!.Width = 100;

            // Formatar colunas de preço
            DGV_PDV.Columns["PrecoUnitario"]!.DefaultCellStyle.Format = "C2";
            DGV_PDV.Columns["TotalItem"]!.DefaultCellStyle.Format = "C2";

            // Configurar evento de duplo clique para remover item
            DGV_PDV.CellDoubleClick += DGV_PDV_CellDoubleClick!;
        }


        // Eventos de teclado para facilitar a navegação
        private void TB_Codigo_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto();
            }
        }

        private void TB_Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularTotalItem();
                TB_PrecoUnit.Focus();
            }
        }

        private void TB_PrecoUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdicionarItem();
            }
        }

        //  Métodos principais do PDV
        private void BuscarProduto()
        {
            if (string.IsNullOrWhiteSpace(TB_Codigo_Produto.Text))
            {
                MessageBox.Show("Digite o código do produto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar produto no banco de dados
                var conexaoBanco = new DBConfig();
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();
                    var select = new Select();

                    // Buscar produto por código ou ID
                    string query = "SELECT * FROM Produto WHERE id_produto = @id_produto OR id_produto = @id_produto";
                    var resultados = select.ExecutarSelectComParametros(query, new Dictionary<string, object>
                    {
                        { "@id_produto", TB_Codigo_Produto.Text.Trim() }
                    });

                    if (resultados.Count > 0)
                    {
                        var produto = resultados[0];

                        // Preencher campos com dados do produto
                        TB_Nome_Mercadoria.Text = produto.ContainsKey("nome") ? produto["nome"].ToString() : "";
                        TB_PrecoUnit.Text = produto.ContainsKey("preco") ? produto["preco"].ToString() : "0";
                        TB_Volume.Text = produto.ContainsKey("quantidade") ? produto["quantidade"].ToString() : "0";

                        // Calcular total do item
                        CalcularTotalItem();

                        // Focar na quantidade
                        TB_Quantidade.Focus();
                        TB_Quantidade.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimparCamposProduto();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produto: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Calcular o total do item com base no preço unitário e quantidade
        private void CalcularTotalItem()
        {
            try
            {
                if (decimal.TryParse(TB_PrecoUnit.Text, out decimal preco) &&
                    int.TryParse(TB_Quantidade.Text, out int quantidade))
                {
                    decimal totalItem = preco * quantidade;
                    TB_Total_Item.Text = totalItem.ToString("C2");
                }
                else
                {
                    TB_Total_Item.Text = "R$ 0,00";
                }
            }
            catch
            {
                TB_Total_Item.Text = "R$ 0,00";
            }
        }

        // Adicionar item à lista de venda
        private void AdicionarItem()
        {
            if (string.IsNullOrWhiteSpace(TB_Codigo_Produto.Text) ||
                string.IsNullOrWhiteSpace(TB_Nome_Mercadoria.Text))
            {
                MessageBox.Show("Busque um produto primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TB_PrecoUnit.Text, out decimal preco) ||
                !int.TryParse(TB_Quantidade.Text, out int quantidade))
            {
                MessageBox.Show("Preço e quantidade devem ser números válidos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se o produto já existe na lista
            var itemExistente = itensVenda.FirstOrDefault(i => i.Codigo == TB_Codigo_Produto.Text);

            if (itemExistente != null)
            {
                // Atualizar quantidade do item existente
                itemExistente.Quantidade += quantidade;
                itemExistente.TotalItem = itemExistente.Quantidade * itemExistente.PrecoUnitario;
            }
            else
            {
                // Adicionar novo item
                var novoItem = new ItemVenda
                {
                    Codigo = TB_Codigo_Produto.Text,
                    Nome = TB_Nome_Mercadoria.Text,
                    Quantidade = quantidade,
                    PrecoUnitario = preco,
                    TotalItem = preco * quantidade
                };
                itensVenda.Add(novoItem);
            }

            // Atualizar DataGridView e total
            AtualizarDataGridView();
            CalcularTotalVenda();

            // Limpar campos e focar no código
            LimparCamposProduto();
            TB_Codigo_Produto.Focus();
        }

        // Atualizar DataGridView com os itens da venda
        private void AtualizarDataGridView()
        {
            DGV_PDV.Rows.Clear();

            foreach (var item in itensVenda)
            {
                DGV_PDV.Rows.Add(
                    item.Codigo,
                    item.Nome,
                    item.Quantidade,
                    item.PrecoUnitario,
                    item.TotalItem
                );
            }
        }
        // Calcular o total da venda somando os totais dos itens
        private void CalcularTotalVenda()
        {
            totalVenda = itensVenda.Sum(i => i.TotalItem);
            TB_Subtotal.Text = totalVenda.ToString("C2");
        }
        // Limpar os campos de produto para a próxima entrada
        private void LimparCamposProduto()
        {
            TB_Codigo_Produto.Clear();
            TB_Nome_Mercadoria.Clear();
            TB_PrecoUnit.Clear();
            TB_Quantidade.Text = "1";
            TB_Total_Item.Text = "R$ 0,00";
        }
        // Finalizar a venda, atualizar o estoque e limpar a venda atual
        private void FinalizarVenda()
        {
            if (itensVenda.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item à venda.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show($"Finalizar venda no valor de {totalVenda:C2}?",
                "Confirmar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                var conexaoBanco = new DBConfig();
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();

                    foreach (var item in itensVenda)
                    {
                        string sql = @"UPDATE Produto 
                               SET quantidade = quantidade - @qtd
                               WHERE id_produto = @id";

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmd.Parameters.AddWithValue("@id", item.Codigo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Depois de atualizar o estoque, limpa a venda atual
                itensVenda.Clear();
                totalVenda = 0;
                AtualizarDataGridView();
                TB_Subtotal.Text = "R$ 0,00";
                LimparCamposProduto();

                MessageBox.Show("Venda finalizada e estoque atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancelar a venda atual
        private void CancelarVenda()
        {
            var resultado = MessageBox.Show("Cancelar venda atual?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                itensVenda.Clear();
                totalVenda = 0;
                AtualizarDataGridView();
                TB_Subtotal.Text = "R$ 0,00";
                LimparCamposProduto();
            }
        }

        // Eventos de clique dos botões
        private void BtnFinalizarVenda_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }

        // Evento de clique do botão Cancelar Venda
        private void BtnCancelarVenda_Click(object sender, EventArgs e)
        {
            CancelarVenda();
        }

        // Evento de duplo clique na DataGridView para remover item
        private void DGV_PDV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < itensVenda.Count)
            {
                var resultado = MessageBox.Show("Remover este item da venda?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    itensVenda.RemoveAt(e.RowIndex);
                    AtualizarDataGridView();
                    CalcularTotalVenda();
                }
            }
        }

        // Atalhos de teclado para ações rápidas
        private void PDV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    // Finalizar venda
                    FinalizarVenda();
                    break;
                case Keys.F2:
                    // Cancelar venda
                    CancelarVenda();
                    break;
                case Keys.F3:
                    // Focar no campo de código
                    TB_Codigo_Produto.Focus();
                    break;
                case Keys.Escape:
                    // Limpar campos
                    LimparCamposProduto();
                    TB_Codigo_Produto.Focus();
                    break;
            }
        }
       

       
        
    }
}
