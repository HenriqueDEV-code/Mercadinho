using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Gestao_Mercadinho.Model
{
    internal class Select
    {
        private readonly DBConfig _dbConfig;

        public Select()
        {
            _dbConfig = new DBConfig();
        }

        // Exemplo de método para executar um SELECT e retornar os resultados em uma lista de dicionários
        public List<Dictionary<string, object>> ExecutarSelect(string query)
        {
            var resultados = new List<Dictionary<string, object>>();

            using (var conn = _dbConfig.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var linha = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                linha[reader.GetName(i)] = reader.GetValue(i);
                            }
                            resultados.Add(linha);
                        }
                    }
                }
            }

            // Vai retornar uma lista de dicionários, onde cada dicionário representa uma linha do resultado do SELECT,
            // com as colunas como chave e os valores como valor.
            return resultados;
        }
    }
}
