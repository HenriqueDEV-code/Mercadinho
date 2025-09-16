using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Gestao_Mercadinho.Model
{
    internal class Update
    {
        private readonly DBConfig _dbConfig;

        public Update()
        {
            _dbConfig = new DBConfig();
        }

        /// <summary>
        /// Executa um UPDATE simples (sem parâmetros).
        /// Retorna o número de linhas afetadas.
        /// </summary>
        public int ExecutarUpdate(string query)
        {
            using (var conn = _dbConfig.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executa um UPDATE com parâmetros.
        /// Retorna o número de linhas afetadas.
        /// </summary>
        public int ExecutarUpdateComParametros(string query, Dictionary<string, object> parametros)
        {
            using (var conn = _dbConfig.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
