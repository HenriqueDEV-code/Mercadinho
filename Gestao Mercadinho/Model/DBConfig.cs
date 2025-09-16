using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace Gestao_Mercadinho.Model
{
    // / <summary>
    // / Classe para gerenciar a configuração do banco de dados e fornecer conexões SQL
    // / </summary>
    public class DBConfig
    {
        // String de conexão lida do arquivo JSON
        private readonly string _connectionString;


        // Construtor que lê a configuração do arquivo JSON
        public DBConfig()
        {
            // Vai ler o arquivo JSON
            var configText = File.ReadAllText("Config/Config.json");
            var config = JsonSerializer.Deserialize<ConfigModel>(configText);
            _connectionString = config?.ConnectionStrings?["MercadinhoDB"] ?? throw new InvalidOperationException("String de conexão não encontrada no arquivo de configuração.");
        }

        // Método para obter uma nova conexão SQL
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        // Classe auxiliar para deserializar o JSON
        public class ConfigModel
        {
            public Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();
            public string ProviderName { get; set; } = string.Empty;
        }

    }
}
