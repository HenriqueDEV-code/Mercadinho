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
    public class DBConfig
    {
        private readonly string _connectionString;

        public DBConfig()
        {
            // Vai ler o arquivo JSON
            var configText = File.ReadAllText("Config/Config.json");
            var config = JsonSerializer.Deserialize<ConfigModel>(configText);
            _connectionString = config.ConnectionStrings["MercadinhoDB"];
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        // Classe auxiliar para deserializar o JSON
        public class ConfigModel
        {
            public Dictionary<string, string> ConnectionStrings { get; set; }
            public string ProviderName { get; set; }
        }

    }
}
