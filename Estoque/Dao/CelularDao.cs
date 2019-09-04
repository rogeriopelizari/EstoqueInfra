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
    public class CelularDao
    {
        private readonly string _connectionString;

        public CelularDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public List<CelularModel> Listar(CelularModel obj)
        {
            List<CelularModel> lista = new List<CelularModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Celular WHERE 1 = 1";

                    if(obj != null)
                    {
                        if (!string.IsNullOrWhiteSpace(obj.Imei))
                            query += $" AND Imei LIKE '{obj.Imei}%'";

                        if (!string.IsNullOrWhiteSpace(obj.Marca))
                            query += $" AND Marca LIKE '{obj.Marca}%'";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new CelularModel
                        {
                            Id = reader.GetInt32(0),
                            Imei = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Antigocolab = SafeGetString(reader, 4),
                            Atualcolab = SafeGetString(reader, 5),
                            Dtacompra = SafeGetString(reader, 6),
                            Status = SafeGetString(reader, 7),
                            Estado = SafeGetString(reader, 8),
                            Obs = SafeGetString(reader, 9)
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

        public CelularModel Obter(int id)
        {
            CelularModel entity = new CelularModel();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Celular WHERE Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        entity = new CelularModel
                        {
                            Id = reader.GetInt32(0),
                            Imei = SafeGetString(reader, 1),
                            Marca = SafeGetString(reader, 2),
                            Modelo = SafeGetString(reader, 3),
                            Antigocolab = SafeGetString(reader, 4),
                            Atualcolab = SafeGetString(reader, 5),
                            Dtacompra = SafeGetString(reader, 6),
                            Status = SafeGetString(reader, 7),
                            Estado = SafeGetString(reader, 8),
                            Obs = SafeGetString(reader, 9)
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

        public int Inserir(CelularModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO [dbo].[Celular]" +
                    $"              ([Imei]" +
                    $"              ,[Marca]" +
                    $"              ,[Modelo]" +
                    $"              ,[Antigocolab]" +
                    $"              ,[Atualcolab]" +
                    $"              ,[Dtacompra]" +
                    $"              ,[Status]" +
                    $"              ,[Estado]" +
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
                    $"              ,@p9) ";
                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Imei);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Antigocolab);
                    FillParameter(command, "p5", obj.Atualcolab);
                    FillParameter(command, "p6", obj.Dtacompra);
                    FillParameter(command, "p7", obj.Status);
                    FillParameter(command, "p8", obj.Estado);
                    FillParameter(command, "p9", obj.Obs);

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

        public int Editar(CelularModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"UPDATE [dbo].[Celular]" +
                    $"                  SET [Imei] = @p1" +
                    $"                     ,[Marca] = @p2" +
                    $"                     ,[Modelo] = @p3" +
                    $"                     ,[Antigocolab] = @p4" +
                    $"                     ,[Atualcolab] = @p5" +
                    $"                     ,[Dtacompra] = @p6" +
                    $"                     ,[Status] = @p7" +
                    $"                     ,[Estado] = @p8" +
                    $"                     ,[Obs] = @p9" +
                    $"               WHERE  [Id] = @p10";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Imei);
                    FillParameter(command, "p2", obj.Marca);
                    FillParameter(command, "p3", obj.Modelo);
                    FillParameter(command, "p4", obj.Antigocolab);
                    FillParameter(command, "p5", obj.Atualcolab);
                    FillParameter(command, "p6", obj.Dtacompra);
                    FillParameter(command, "p7", obj.Status);
                    FillParameter(command, "p8", obj.Estado);
                    FillParameter(command, "p9", obj.Obs);
                    FillParameter(command, "p10", obj.Id);

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

        public int Deletar(CelularModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"DELETE FROM [dbo].[Celular]" +
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

        //public List<EstoqueFiltroViewModel> filtro (EstoqueFiltroViewModel obj)
        //{
        //    List<CelularModel> lista = new List<CelularModel>();
        //    SqlConnection connection = null;
        //    try
        //    {
        //        using (connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            string query = $"SELECT * FROM Celular";

        //            SqlCommand command = new SqlCommand(query, connection);
        //            var reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                lista.Add(new CelularModel
        //                {
        //                    Id = reader.GetInt32(0),
        //                    Imei = SafeGetString(reader, 1),
        //                    Marca = SafeGetString(reader, 2),
        //                    Modelo = SafeGetString(reader, 3),
        //                    Antigocolab = SafeGetString(reader, 4),
        //                    Atualcolab = SafeGetString(reader, 5),
        //                    Dtacompra = SafeGetString(reader, 6),
        //                    Status = SafeGetString(reader, 7),
        //                    Estado = SafeGetString(reader, 8),
        //                    Obs = SafeGetString(reader, 9)
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (connection?.State == ConnectionState.Open)
        //            connection.Close();
        //    }

        //    return filtro;
        //}

    }
}
