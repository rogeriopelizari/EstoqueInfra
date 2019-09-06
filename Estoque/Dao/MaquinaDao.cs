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
    public class MaquinaDao
    {
        private string _connectionString;

        public MaquinaDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public List<MaquinaModel> Listar(MaquinaModel obj)
        {
            List<MaquinaModel> lista = new List<MaquinaModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Maquina WHERE 1 = 1";

                    if (obj != null)
                    {
                        if (!string.IsNullOrWhiteSpace(obj.Patrimonio))
                            query += $" AND Patrimonio LIKE '{obj.Patrimonio}%'";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new MaquinaModel
                        {
                            Id = reader.GetInt32(0),
                            Patrimonio = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Servtag = SafeGetString(reader, 4),
                            Tipo = SafeGetString(reader, 5),
                            Numserie = SafeGetString(reader, 6),
                            Status = SafeGetString(reader, 7),
                            Estado = SafeGetString(reader, 8),
                            Proc = SafeGetString(reader, 9),
                            Mem = SafeGetString(reader, 10),
                            Hd = SafeGetString(reader, 11),
                            Antcolab = SafeGetString(reader, 12),
                            Atualcolab = SafeGetString(reader, 13),
                            Dtacompra = SafeGetString(reader, 14),
                            Dtatroca = SafeGetString(reader, 15),
                            Obs = SafeGetString(reader, 16)
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

        public MaquinaModel Obter(int id)
        {
            MaquinaModel entity = new MaquinaModel();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Maquina WHERE Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        entity = new MaquinaModel
                        {
                            Id = reader.GetInt32(0),
                            Patrimonio = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Servtag = SafeGetString(reader, 4),
                            Tipo = SafeGetString(reader, 5),
                            Numserie = SafeGetString(reader, 6),
                            Status = SafeGetString(reader, 7),
                            Estado = SafeGetString(reader, 8),
                            Proc = SafeGetString(reader, 9),
                            Mem = SafeGetString(reader, 10),
                            Hd = SafeGetString(reader, 11),
                            Antcolab = SafeGetString(reader, 12),
                            Atualcolab = SafeGetString(reader, 13),
                            Dtacompra = SafeGetString(reader, 14),
                            Dtatroca = SafeGetString(reader, 15),
                            Obs = SafeGetString(reader, 16)
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

        public int Inserir(MaquinaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO [dbo].[Maquina]" +
                    $"              ([Patrimonio]" +
                    $"              ,[Marca]" +
                    $"              ,[Modelo]" +
                    $"              ,[Servtag]" +
                    $"              ,[Tipo]" +
                    $"              ,[Numserie]" +
                    $"              ,[Status]" +
                    $"              ,[Estado]" +
                    $"              ,[Proc]" +
                    $"              ,[Mem]" +
                    $"              ,[Hd]" +
                    $"              ,[Antcolab]" +
                    $"              ,[Atualcolab]" +
                    $"              ,[Dtacompra]" +
                    $"              ,[Dtatroca]" +
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
                    $"              ,@p10" +
                    $"              ,@p11" +
                    $"              ,@p12" +
                    $"              ,@p13" +
                    $"              ,@p14" +
                    $"              ,@p15" +
                    $"              ,@p16)" ;

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Patrimonio);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Servtag);
                    FillParameter(command, "p5", obj.Tipo);
                    FillParameter(command, "p6", obj.Numserie);
                    FillParameter(command, "p7", obj.Status);
                    FillParameter(command, "p8", obj.Estado);
                    FillParameter(command, "p9", obj.Proc);
                    FillParameter(command, "p10", obj.Mem);
                    FillParameter(command, "p11", obj.Hd);
                    FillParameter(command, "p12", obj.Antcolab);
                    FillParameter(command, "p13", obj.Atualcolab);
                    FillParameter(command, "p14", obj.Dtacompra);
                    FillParameter(command, "p15", obj.Dtatroca);
                    FillParameter(command, "p16", obj.Obs);

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

        public int Editar(MaquinaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"UPDATE [dbo].[Maquina]" +
                    $"                  SET [Patrimonio] = @p1" +
                    $"                     ,[Marca] = @p2" +
                    $"                     ,[Modelo] = @p3" +
                    $"                     ,[Servtag] = @p4" +
                    $"                     ,[Tipo] = @p5" +
                    $"                     ,[Numserie] = @p6" +
                    $"                     ,[Status] = @p7" +
                    $"                     ,[Estado] = @p8" +
                    $"                     ,[Proc] = @p9" +
                    $"                     ,[Mem] = @p10" +
                    $"                     ,[Hd] = @p11" +
                    $"                     ,[Antcolab] = @p12" +
                    $"                     ,[Atualcolab] = @p13" +
                    $"                     ,[Dtacompra] = @p14" +
                    $"                     ,[Dtatroca] = @p15" +
                    $"                     ,[Obs] = @p16" +
                    $"               WHERE  [Id] = @p17";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Patrimonio);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Servtag);
                    FillParameter(command, "p5", obj.Tipo);
                    FillParameter(command, "p6", obj.Numserie);
                    FillParameter(command, "p7", obj.Status);
                    FillParameter(command, "p8", obj.Estado);
                    FillParameter(command, "p9", obj.Proc);
                    FillParameter(command, "p10", obj.Mem);
                    FillParameter(command, "p11", obj.Hd);
                    FillParameter(command, "p12", obj.Antcolab);
                    FillParameter(command, "p13", obj.Atualcolab);
                    FillParameter(command, "p14", obj.Dtacompra);
                    FillParameter(command, "p15", obj.Dtatroca);
                    FillParameter(command, "p16", obj.Obs);
                    FillParameter(command, "p17", obj.Id);

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

        public int Deletar(MaquinaModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"DELETE FROM [dbo].[Maquina]" +
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