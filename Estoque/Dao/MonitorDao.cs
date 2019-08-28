using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Estoque.Dao
{
    public class MonitorDao
    {
        private string _connectionString;

        public MonitorDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public List<MonitorModel> Listar(MonitorModel obj)
        {
            List<MonitorModel> lista = new List<MonitorModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Monitor";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new MonitorModel
                        {
                            Id = reader.GetInt32(0),
                            Patrimonio = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Nserie = SafeGetString(reader, 4),
                            Status = SafeGetString(reader, 5),
                            Estado = SafeGetString(reader, 6),
                            Antcolab = SafeGetString(reader, 7),
                            Atualcolab = SafeGetString(reader, 8),
                            Dtacompra = SafeGetString(reader, 9),
                            Obs = SafeGetString(reader, 10)
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

        public MonitorModel Obter(int id)
        {
            MonitorModel entity = new MonitorModel();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Monitor WHERE Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        entity = new MonitorModel
                        {
                            Id = reader.GetInt32(0),
                            Patrimonio = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Nserie = SafeGetString(reader, 4),
                            Status = SafeGetString(reader, 5),
                            Estado = SafeGetString(reader, 6),
                            Antcolab = SafeGetString(reader, 7),
                            Atualcolab = SafeGetString(reader, 8),
                            Dtacompra = SafeGetString(reader, 9),
                            Obs = SafeGetString(reader, 10)
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

        public int Inserir(MonitorModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO [dbo].[Monitor]" +
                    $"              ([Patrimonio]" +
                    $"              ,[Marca]" +
                    $"              ,[Modelo]" +
                    $"              ,[Nserie]" +
                    $"              ,[Status]" +
                    $"              ,[Estado]" +
                    $"              ,[Antcolab]" +
                    $"              ,[Atualcolab]" +
                    $"              ,[Dtacompra]" +
                    $"              ,[Obs])" +
                    $"              VALUES" +
                    $"              (@p1" +
                    $"              ,@p2" +
                    $"              ,@p3" +
                    $"              ,@p4" +
                    $"              ,@p5" +
                    $"              ,@p6" +
                    $"              ,@p7" +
                    $"              ,@p8" +
                    $"              ,@p9" +
                    $"              ,@p10)" ;

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Patrimonio);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Nserie);
                    FillParameter(command, "p5", obj.Status);
                    FillParameter(command, "p6", obj.Estado);
                    FillParameter(command, "p7", obj.Antcolab);
                    FillParameter(command, "p8", obj.Atualcolab);
                    FillParameter(command, "p9", obj.Dtacompra);
                    FillParameter(command, "p10", obj.Obs);
                    
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

        public int Editar(MonitorModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"UPDATE [dbo].[Monitor]" +
                    $"                  SET [Patrimonio] = @p1" +
                    $"                     ,[Marca] = @p2" +
                    $"                     ,[Modelo] = @p3" +
                    $"                     ,[Nserie] = @p4" +
                    $"                     ,[Status] = @p5" +
                    $"                     ,[Estado] = @p6" +
                    $"                     ,[Antcolab] = @p7" +
                    $"                     ,[Atualcolab] = @p8" +
                    $"                     ,[Dtacompra] = @p9" +
                    $"                     ,[Obs] = @p10" +
                    $"               WHERE  [Id] = @p11";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Patrimonio);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Nserie);
                    FillParameter(command, "p5", obj.Status);
                    FillParameter(command, "p6", obj.Estado);
                    FillParameter(command, "p7", obj.Antcolab);
                    FillParameter(command, "p8", obj.Atualcolab);
                    FillParameter(command, "p9", obj.Dtacompra);
                    FillParameter(command, "p10", obj.Obs);
                    FillParameter(command, "p11", obj.Id);

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

        public int Deletar(MonitorModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"DELETE FROM [dbo].[Monitor]" +
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