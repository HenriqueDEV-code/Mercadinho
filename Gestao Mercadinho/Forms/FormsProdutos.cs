using System;
using System.Windows.Forms;
using Gestao_Mercadinho.Model;
using Gestao_Mercadinho.Forms;
using System.Data;
using Microsoft.Data.SqlClient;


/// <summary>
///  Mini sistema de Lista de Produtos e Incremento para simbolisar uma Adicao na quantidade de Produtos na tabela @Produto
/// </summary>



namespace Gestao_Mercadinho.Forms
{
    public partial class Produtos : Form
    {
        Cadastrar JanelaCadastro = new Cadastrar();
        public Produtos()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            this.Load += (s, e) =>
            {
                CarregarTabela();
            };
            // Permita que o formulario capture eventos do teclado
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Produtos_KeyDown!);
        }

        private void Produtos_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é "Escape"
            if (e.KeyCode == Keys.Enter)
            {
                btn_Pesquisa_Busca.PerformClick();
            }
        }

        private void ConfigurarDataGridView()
        {
            // Configurar propriedades da DataGridView
            DGV_Lista_Produtos.AutoGenerateColumns = false;
            DGV_Lista_Produtos.AllowUserToAddRows = false;
            DGV_Lista_Produtos.AllowUserToDeleteRows = false;
            DGV_Lista_Produtos.ReadOnly = true;
            DGV_Lista_Produtos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Lista_Produtos.MultiSelect = false;
            DGV_Lista_Produtos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Lista_Produtos.RowHeadersVisible = false;
        }

        // Metodo para testar a conexao com o banco de dados
        public static bool TestarConexao()
        {
             var conexaoBanco = new DBConfig();
            try
            {
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
            try
            {
                // Verifica se a janela já está aberta
                if (JanelaCadastro.IsDisposed)
                {
                    JanelaCadastro = new Cadastrar();
                }
                
                // Configurar evento para atualizar a lista quando o formulário for fechado
                JanelaCadastro.FormClosed += (s, args) => CarregarTabela();
                
                // Mostra a janela de cadastro
                JanelaCadastro.Show();
                JanelaCadastro.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir janela de cadastro: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Pesquisa_Busca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Busca.Text))
            {
                CarregarTabela();
            }
            else
            {
                BuscarProdutos(TB_Busca.Text.Trim());
            }
        }

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
                    
                    // Limpar dados existentes na DataGridView
                    DGV_Lista_Produtos.Rows.Clear();
                    DGV_Lista_Produtos.Columns.Clear();
                    
                    // Configurar colunas fixas
                    ConfigurarColunas();
                    
                    if (resultados.Count > 0)
                    {
                        // Adicionar os resultados na DataGridView
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
        
        

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

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
                    
                    // Limpar dados existentes na DataGridView
                    DGV_Lista_Produtos.Rows.Clear();
                    DGV_Lista_Produtos.Columns.Clear();
                    
                    // Configurar colunas fixas
                    ConfigurarColunas();
                    
                    if (resultados.Count > 0)
                    {
                        // Adicionar os resultados na DataGridView
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

        private void ConfigurarColunas()
        {
            // Adicionar colunas com nomes em português
            DGV_Lista_Produtos.Columns.Add("id", "ID");
            DGV_Lista_Produtos.Columns.Add("nome", "Nome");
            DGV_Lista_Produtos.Columns.Add("preco", "Preço");
            DGV_Lista_Produtos.Columns.Add("quantidade", "Quantidade");
            
            // Configurar largura das colunas
            DGV_Lista_Produtos.Columns["id"]!.Width = 80;
            DGV_Lista_Produtos.Columns["nome"]!.Width = 300;
            DGV_Lista_Produtos.Columns["preco"]!.Width = 120;
            DGV_Lista_Produtos.Columns["quantidade"]!.Width = 120;
            
            // Formatar coluna de preço
            DGV_Lista_Produtos.Columns["preco"]!.DefaultCellStyle.Format = "C2"; // Formato de moeda
        }

        private static bool _debugColunasMostrado = false;

        private object[] MapearLinhaParaDataGridView(Dictionary<string, object> linha)
        {
            var row = new object[4]; // ID, Nome, Preço, Quantidade
            
            // Debug: mostrar as colunas disponíveis apenas uma vez
            if (!_debugColunasMostrado)
            {
                System.Diagnostics.Debug.WriteLine("Colunas disponíveis:");
                foreach (var coluna in linha.Keys)
                {
                    System.Diagnostics.Debug.WriteLine($"- {coluna}: {linha[coluna]}");
                }
                _debugColunasMostrado = true;
            }
            
            // Tentar diferentes variações do nome da coluna ID
            row[0] = linha.ContainsKey("id") ? linha["id"] : 
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
    }
}
