using System;
using System.Collections.Generic; // <-- necessário para Dictionary
using System.Windows.Forms;
using Gestao_Mercadinho.Model;
using Gestao_Mercadinho.Forms;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Gestao_Mercadinho.Forms
{
    public partial class Produtos : Form
    {
        Cadastrar JanelaCadastro = new Cadastrar();

        public Produtos()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            this.Load += (s, e) => { CarregarTabela(); };

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Produtos_KeyDown!);

            // Handler de clique nas células (botões)
            DGV_Lista_Produtos.CellClick += DGV_Lista_Produtos_CellClick;
            DGV_Lista_Produtos.CellPainting += DGV_Lista_Produtos_CellPainting;

        }

        private void Produtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Pesquisa_Busca.PerformClick();
        }

        // ====== NOVO: helper para obter o ID da linha ======
        private int? ObterIdDaLinha(DataGridViewRow row)
        {
            string[] candidatos = { "id", "id_produto", "Id", "ID", "codigo", "Codigo" };

            foreach (var nome in candidatos)
            {
                if (DGV_Lista_Produtos.Columns.Contains(nome))
                {
                    var val = row.Cells[nome].Value?.ToString();
                    if (int.TryParse(val, out int idOk))
                        return idOk;
                }
            }

            // Fallback: tenta primeira célula da linha
            if (row.Cells.Count > 0)
            {
                var val0 = row.Cells[0].Value?.ToString();
                if (int.TryParse(val0, out int id0))
                    return id0;
            }

            return null;
        }


        // Handler para cliques nas células (botões +1 e -1)
        private void DGV_Lista_Produtos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // cabeçalho

            var nomeColuna = DGV_Lista_Produtos.Columns[e.ColumnIndex].Name;
            var row = DGV_Lista_Produtos.Rows[e.RowIndex];

            var idOpt = ObterIdDaLinha(row);
            if (idOpt is null)
            {
                MessageBox.Show("Não foi possível identificar o ID do produto para esta linha.");
                return;
            }
            int id = idOpt.Value;

            switch (nomeColuna)
            {
                case "colInc":
                    IncrementarQuantidade(id, +1);
                    break;
                case "colDec":
                    IncrementarQuantidade(id, -1);
                    break;
            }
        }

        // Atualiza a quantidade do produto no banco de dados
        private void IncrementarQuantidade(int id, int delta)
        {
            try
            {
                var update = new Update();

                string sql = @"
                            UPDATE Produto
                            SET quantidade = CASE 
                            WHEN quantidade + @delta < 0 THEN 0 
                            ELSE quantidade + @delta 
                            END
                            WHERE id_produto = @id;";

                var parametros = new Dictionary<string, object>
                {
                    { "@delta", delta },
                    { "@id", id }
                };

                int afetados = update.ExecutarUpdateComParametros(sql, parametros);

                if (afetados > 0)
                    CarregarTabela();
                else
                    MessageBox.Show("Produto não encontrado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar quantidade: " + ex.Message);
            }
        }

        // Configurações do DataGridView
        private void ConfigurarDataGridView()
        {
            DGV_Lista_Produtos.AutoGenerateColumns = false;
            DGV_Lista_Produtos.AllowUserToAddRows = false;
            DGV_Lista_Produtos.AllowUserToDeleteRows = false;
            DGV_Lista_Produtos.ReadOnly = true;
            DGV_Lista_Produtos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Lista_Produtos.MultiSelect = false;
            DGV_Lista_Produtos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Lista_Produtos.RowHeadersVisible = false;
        }

        // Testa a conexão com o banco de dados
        public static bool TestarConexao()
        {
            var conexaoBanco = new DBConfig();
            try
            {
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Conexao bem sucedida: ");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
                return false;
            }
        }


        // Botão Adicionar Produto
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            abrirJanela();
        }

        // Abre a janela de cadastro
        private void abrirJanela()
        {
            try
            {
                if (JanelaCadastro.IsDisposed)
                    JanelaCadastro = new Cadastrar();

                JanelaCadastro.FormClosed += (s, args) => CarregarTabela();

                JanelaCadastro.Show();
                JanelaCadastro.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir janela de cadastro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Botão Pesquisar

        private void btn_Pesquisa_Busca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Busca.Text))
                CarregarTabela();
            else
                BuscarProdutos(TB_Busca.Text.Trim());
        }





        // Busca produtos no banco de dados com base no termo de busca
        private void BuscarProdutos(string termoBusca)
        {
            var conexaoBanco = new DBConfig();

            try
            {
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();
                    var select = new Select();
                    string query = "SELECT * FROM Produto WHERE nome LIKE @termo OR Descricao LIKE @termo";
                    var resultados = select.ExecutarSelectComParametros(query, new Dictionary<string, object>
                    {
                        { "@termo", $"%{termoBusca}%" }
                    });

                    DGV_Lista_Produtos.Rows.Clear();
                    DGV_Lista_Produtos.Columns.Clear();

                    ConfigurarColunas();

                    if (resultados.Count > 0)
                    {
                        foreach (var linha in resultados)
                        {
                            var row = MapearLinhaParaDataGridView(linha);
                            DGV_Lista_Produtos.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao buscar produtos: {ex.Message}");
                MessageBox.Show($"Erro ao buscar produtos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carrega os dados do banco de dados para o DataGridView

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }



        // Carrega os dados do banco de dados para o DataGridView

        private void CarregarTabela()
        {
            var conexaoBanco = new DBConfig();

            try
            {
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();
                    var select = new Select();
                    string query = "SELECT * FROM Produto";
                    var resultados = select.ExecutarSelect(query);

                    DGV_Lista_Produtos.Rows.Clear();
                    DGV_Lista_Produtos.Columns.Clear();

                    ConfigurarColunas();

                    if (resultados.Count > 0)
                    {
                        foreach (var linha in resultados)
                        {
                            var row = MapearLinhaParaDataGridView(linha);
                            DGV_Lista_Produtos.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar dados: {ex.Message}");
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Customiza a aparência dos botões +1 e -1
        private void DGV_Lista_Produtos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignora cabeçalho

            // Botão +1 (verde)
            if (DGV_Lista_Produtos.Columns[e.ColumnIndex].Name == "colInc")
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.ForeColor = Color.Black;
            }

            // Botão -1 (vermelho)
            if (DGV_Lista_Produtos.Columns[e.ColumnIndex].Name == "colDec")
            {
                e.CellStyle.BackColor = Color.LightCoral;
                e.CellStyle.ForeColor = Color.Black;
            }
        }


        // Configura as colunas do DataGridView

        private void ConfigurarColunas()
        {
            DGV_Lista_Produtos.Columns.Add("id", "ID");
            DGV_Lista_Produtos.Columns.Add("nome", "Nome");
            DGV_Lista_Produtos.Columns.Add("preco", "Preço");
            DGV_Lista_Produtos.Columns.Add("quantidade", "Quantidade");

            DGV_Lista_Produtos.Columns["id"]!.Width = 80;
            DGV_Lista_Produtos.Columns["nome"]!.Width = 300;
            DGV_Lista_Produtos.Columns["preco"]!.Width = 120;
            DGV_Lista_Produtos.Columns["quantidade"]!.Width = 120;

            DGV_Lista_Produtos.Columns["preco"]!.DefaultCellStyle.Format = "C2";

            AdicionarAcao();
            DGV_Lista_Produtos.Columns["colInc"]!.Width = 60;
            DGV_Lista_Produtos.Columns["colDec"]!.Width = 60;
        }

        // Mapeia uma linha do banco de dados para uma linha do DataGridView
        private static bool _debugColunasMostrado = false;



        // Mapeia uma linha do banco de dados para uma linha do DataGridView
        private object[] MapearLinhaParaDataGridView(Dictionary<string, object> linha)
        {
            var row = new object[4]; // ID, Nome, Preço, Quantidade

            if (!_debugColunasMostrado)
            {
                System.Diagnostics.Debug.WriteLine("Colunas disponíveis:");
                foreach (var coluna in linha.Keys)
                    System.Diagnostics.Debug.WriteLine($"- {coluna}: {linha[coluna]}");
                _debugColunasMostrado = true;
            }

            row[0] = linha.ContainsKey("id") ? linha["id"] :
                     linha.ContainsKey("id_produto") ? linha["id_produto"] :
                     linha.ContainsKey("Id") ? linha["Id"] :
                     linha.ContainsKey("ID") ? linha["ID"] :
                     linha.ContainsKey("codigo") ? linha["codigo"] :
                     linha.ContainsKey("Codigo") ? linha["Codigo"] : "";

            row[1] = linha.ContainsKey("nome") ? linha["nome"] :
                     linha.ContainsKey("Nome") ? linha["Nome"] : "";

            row[2] = linha.ContainsKey("preco") ? linha["preco"] :
                     linha.ContainsKey("Preco") ? linha["Preco"] : "";

            row[3] = linha.ContainsKey("quantidade") ? linha["quantidade"] :
                     linha.ContainsKey("Quantidade") ? linha["Quantidade"] : "";

            return row;
        }


        // Adiciona as colunas de ação (+1 e -1)  Buttons ao DataGridView 
        private void AdicionarAcao()
        {
            // Botão +1
            if (!DGV_Lista_Produtos.Columns.Contains("colInc"))
            {
                var colInc = new DataGridViewButtonColumn
                {
                    Name = "colInc",
                    HeaderText = "Adicionar",
                    Text = "➕",
                    UseColumnTextForButtonValue = true,
                    
                };
                DGV_Lista_Produtos.Columns.Add(colInc);
            }

            // Botão -1
            if (!DGV_Lista_Produtos.Columns.Contains("colDec"))
            {
                var colDec = new DataGridViewButtonColumn
                {
                    Name = "colDec",
                    HeaderText = "Retirar",
                    Text = "➖",
                    UseColumnTextForButtonValue = true,
                   
                };
                DGV_Lista_Produtos.Columns.Add(colDec);
            }
        }
    }
}