using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestao_Mercadinho.Model;
using Microsoft.Data.SqlClient;



/// <summary>
///  Mini sistema de Cadastro para simbolisar um sistema de Cadastro de Produtos na tabela @Produto
/// </summary>


namespace Gestao_Mercadinho.Forms
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();

            // Permita que o formulario capture eventos do teclado
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Cadastrar_KeyDown!);
            
            // Configurar eventos dos botões
            btnSalvar.Click += BtnSalvar_Click!;
            btnCancelar.Click += BtnCancelar_Click!;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome do produto.", "Validação", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPreco.Text))
                {
                    MessageBox.Show("Por favor, preencha o preço do produto.", "Validação", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPreco.Focus();
                    return;
                }

                // Validar se o preço é um número válido
                if (!decimal.TryParse(txtPreco.Text, out decimal preco))
                {
                    MessageBox.Show("Por favor, insira um preço válido.", "Validação", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPreco.Focus();
                    return;
                }

                // Salvar produto no banco de dados
                SalvarProduto();
                
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Limpar campos
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produto: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalvarProduto()
        {
            var conexaoBanco = new DBConfig();
            
            using (var conn = conexaoBanco.GetConnection())
            {
                conn.Open();
                
                string query = @"INSERT INTO Produto (nome, preco, quantidade) 
                               VALUES (@nome, @preco, @quantidade)";
                
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                    cmd.Parameters.AddWithValue("@quantidade", 
                        string.IsNullOrWhiteSpace(txtEstoque.Text) ? 0 : int.Parse(txtEstoque.Text));
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
            txtNome.Focus();
        }

        private void Cadastrar_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é "Escape"
            if (e.KeyCode == Keys.Escape)
            {
                // Feche o formulário
                this.Close();
            }
        }
    }
}
