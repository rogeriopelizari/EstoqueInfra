using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Estoque.Dao
{
    public class UsuarioDao
    {
        private string _connectionString;

        public UsuarioDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public List<UsuarioModel> Listar(UsuarioModel obj)
        {
            List<UsuarioModel> lista = new List<UsuarioModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Usuario";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new UsuarioModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Login = reader.GetString(2),
                            Senha = reader.GetString(3)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(connection?.State == ConnectionState.Open)
                    connection.Close();
            }

            return lista;
        }

        public UsuarioModel Login(string login, string senha)
        {
            SqlConnection connection = null;
            UsuarioModel model = null;

            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * " +
                                   $"  FROM Usuario " +
                                   $" WHERE Login = '{login}' AND Senha = '{senha}'";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        model = new UsuarioModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Login = reader.GetString(2),
                            Senha = reader.GetString(3)
                        };
                    }

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}