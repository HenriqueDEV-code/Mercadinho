using System;
using System.Windows.Forms;
using Gestao_Mercadinho.Model;

namespace Gestao_Mercadinho.Forms
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }










        // Metodo para testar a conexao com o banco de dados
        public static bool TestarConexao()
        {
            try
            {
                var conexaoBanco = new DBConfig();
                using (var conn = conexaoBanco.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Conexao bem sucedida: ");
                    return true; // Conexão bem-sucedida
                }
            }
            catch (Exception ex)
            {
                // Você pode exibir a mensagem de erro ou logar, se preferir
                Console.WriteLine("Erro ao conectar: " + ex.Message);
                return false; // Falha na conexão
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
           TestarConexao(); 
        }
    }
}
