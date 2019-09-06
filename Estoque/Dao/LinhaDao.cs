using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Estoque.Dao
{
    public class LinhaDao
    {
        private readonly string _connectionString;

        public LinhaDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public List<LinhaModel> Listar(LinhaModel obj)
        {
            List<LinhaModel> lista = new List<LinhaModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Linha WHERE 1 = 1";

                    if (obj != null)
                    {
                        if (!string.IsNullOrWhiteSpace(obj.Numero))
                            query += $" AND Numero LIKE '{obj.Numero}%'";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new LinhaModel
                        {
                            Id = reader.GetInt32(0),
                            Simcard = SafeGetString(reader, 1),
                            Numero = reader.GetString(2),
                            Operadora = SafeGetString(reader, 3),
                            Antcolab = SafeGetString(reader, 4),
                            Atualcolab = SafeGetString(reader, 5),
                            Status = SafeGetString(reader, 6),
                            Obs = SafeGetString(reader, 7)
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
                if (connection?.State == ConnectionState.Open)
                    connection.Close();
            }

            return lista;
        }

        public LinhaModel Obter(int id)
        {
            LinhaModel entity = new LinhaModel();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Linha WHERE Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        entity = new LinhaModel
                        {
                            Id = reader.GetInt32(0),
                            Simcard = SafeGetString(reader, 1),
                            Numero = reader.GetString(2),
                            Operadora = SafeGetString(reader, 3),
                            Antcolab = SafeGetString(reader, 4),
                            Atualcolab = SafeGetString(reader, 5),
                            Status = SafeGetString(reader, 6),
                            Obs = SafeGetString(reader, 7)
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                    connection.Close();
            }
            return entity;
        }

        public int Inserir(LinhaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO [dbo].[Linha]" +
                    $"              ([Simcard]" +
                    $"              ,[Numero]" +
                    $"              ,[Operadora]" +
                    $"              ,[Antcolab]" +
                    $"              ,[Atualcolab]" +
                    $"              ,[Status]" +
                    $"              ,[Obs])" +
                    $"              VALUES" +
                    $"              (@p1" +
                    $"              ,@p2" +
                    $"              ,@p3" +
                    $"              ,@p4" +
                    $"              ,@p5" +
                    $"              ,@p6" +
                    $"              ,@p7) ";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Simcard);
                    FillParameter(command, "p2", obj.Numero);
                    FillParameter(command, "p3", obj.Operadora);
                    FillParameter(command, "p4", obj.Antcolab);
                    FillParameter(command, "p5", obj.Atualcolab);
                    FillParameter(command, "p6", obj.Status);
                    FillParameter(command, "p7", obj.Obs);

                    command.ExecuteScalar();
                    return 0;
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

        private void FillParameter(IDbCommand comm, string nomeParametro, object valor)
        {
            if (valor is string && string.IsNullOrEmpty(valor.ToString()))
                valor = null;

            IDbDataParameter dbParameter = comm.CreateParameter();
            dbParameter.ParameterName = nomeParametro;
            dbParameter.Value = valor ?? DBNull.Value;
            comm.Parameters.Add(dbParameter);
        }

        public int Editar(LinhaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"UPDATE [dbo].[Linha]" +
                    $"                  SET [Simcard] = @p1" +
                    $"                     ,[Numero] = @p2" +
                    $"                     ,[Operadora] = @p3" +
                    $"                     ,[Antcolab] = @p4" +
                    $"                     ,[Atualcolab] = @p5" +
                    $"                     ,[Status] = @p6" +
                    $"                     ,[Obs] = @p7" +
                    $"               WHERE  [Id] = @p8";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Simcard);
                    FillParameter(command, "p2", obj.Numero);
                    FillParameter(command, "p3", obj.Operadora);
                    FillParameter(command, "p4", obj.Antcolab);
                    FillParameter(command, "p5", obj.Atualcolab);
                    FillParameter(command, "p6", obj.Status);
                    FillParameter(command, "p7", obj.Obs);
                    FillParameter(command, "p8", obj.Id);

                    command.ExecuteScalar();
                    return 0;
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

        public int Deletar(LinhaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"DELETE FROM [dbo].[Linha]" +
                    $"                WHERE [Id] = {obj.Id}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    command.ExecuteScalar();
                    return 0;
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