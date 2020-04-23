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
    public class FuncionarioDao
    {
        private string _connectionString;

        public FuncionarioDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public List<FuncionarioModel> Listar(FuncionarioModel obj)
        {
            List<FuncionarioModel> lista = new List<FuncionarioModel>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Funcionario WHERE 1 = 1";

                    if (obj != null)
                    {
                        if (!string.IsNullOrWhiteSpace(obj.Nome))
                            query += $" AND Nome LIKE '{obj.Nome}%'";
                    }
                            query += $" ORDER BY Nome";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new FuncionarioModel
                        {
                            Id = reader.GetInt32(0),
                            Matricula = SafeGetString(reader, 1),
                            Nome = SafeGetString(reader, 2),
                            Email = SafeGetString(reader, 3),
                            Cta365 = SafeGetString(reader, 4),
                            Cargo = SafeGetString(reader, 5),
                            Setor = SafeGetString(reader, 6),
                            Gestor = SafeGetString(reader, 7),
                            Dtaadm = SafeGetString(reader, 8),
                            Dtadem = SafeGetString(reader, 9),
                            Statad = SafeGetString(reader, 10),
                            Statjira = SafeGetString(reader, 11),
                            Statconflu = SafeGetString(reader, 12),
                            Statslack = SafeGetString(reader, 13),
                            Door = SafeGetString(reader, 14),
                            Ponto = SafeGetString(reader, 15),
                            Status = SafeGetString(reader, 16),
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

        public FuncionarioModel Obter(int id)
        {
            FuncionarioModel entity = new FuncionarioModel();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Funcionario WHERE Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        entity = new FuncionarioModel
                        {
                            Id = reader.GetInt32(0),
                            Matricula = SafeGetString(reader, 1),
                            Nome = SafeGetString(reader, 2),
                            Email = SafeGetString(reader, 3),
                            Cta365 = SafeGetString(reader, 4),
                            Cargo = SafeGetString(reader, 5),
                            Setor = SafeGetString(reader, 6),
                            Gestor = SafeGetString(reader, 7),
                            Dtaadm = SafeGetString(reader, 8),
                            Dtadem = SafeGetString(reader, 9),
                            Statad = SafeGetString(reader, 10),
                            Statjira = SafeGetString(reader, 11),
                            Statconflu = SafeGetString(reader, 12),
                            Statslack = SafeGetString(reader, 13),
                            Door = SafeGetString(reader, 14),
                            Ponto = SafeGetString(reader, 15),
                            Status = SafeGetString(reader, 16),
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

        public int Inserir(FuncionarioModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO [dbo].[Funcionario]" +
                    $"              ([Matricula]" +
                    $"              ,[Nome]" +
                    $"              ,[Email]" +
                    $"              ,[Cta365]" +
                    $"              ,[Cargo]" +
                    $"              ,[Setor]" +
                    $"              ,[Gestor]" +
                    $"              ,[Dtaadm]" +
                    $"              ,[Dtadem]" +
                    $"              ,[Statad]" +
                    $"              ,[Statjira]" +
                    $"              ,[Statconflu]" +
                    $"              ,[Statslack]" +
                    $"              ,[Door]" +
                    $"              ,[Ponto]" +
                    $"              ,[Status])" +
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
                    $"              ,@p16)";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Matricula);
                    FillParameter(command, "p2", obj.Nome);
                    FillParameter(command, "p3", obj.Email);
                    FillParameter(command, "p4", obj.Cta365);
                    FillParameter(command, "p5", obj.Cargo);
                    FillParameter(command, "p6", obj.Setor);
                    FillParameter(command, "p7", obj.Gestor);
                    FillParameter(command, "p8", obj.Dtaadm);
                    FillParameter(command, "p9", obj.Dtadem);
                    FillParameter(command, "p10", obj.Statad);
                    FillParameter(command, "p11", obj.Statjira);
                    FillParameter(command, "p12", obj.Statconflu);
                    FillParameter(command, "p13", obj.Statslack);
                    FillParameter(command, "p14", obj.Door);
                    FillParameter(command, "p15", obj.Ponto);
                    FillParameter(command, "p16", obj.Status);

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

        public int Editar(FuncionarioModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {
                    string query = $"UPDATE [dbo].[Funcionario]" +
                    $"                  SET " +
                    $"                      [Matricula] = @p1" +
                    $"                     ,[Nome] = @p2" +
                    $"                     ,[Email] = @p3" +
                    $"                     ,[Cta365] = @p4" +
                    $"                     ,[Cargo] = @p5" +
                    $"                     ,[Setor] = @p6" +
                    $"                     ,[Gestor] = @p7" +
                    $"                     ,[Dtaadm] = @p8" +
                    $"                     ,[Dtadem] = @p9" +
                    $"                     ,[Statad] = @p10" +
                    $"                     ,[Statjira] = @p11" +
                    $"                     ,[Statconflu] = @p12" +
                    $"                     ,[Statslack] = @p13" +
                    $"                     ,[Door] = @p14" +
                    $"                     ,[Ponto] = @p15" +
                    $"                     ,[Status] = @p16" +
                    $"               WHERE  [Id] = @p17";

                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection)
                    {
                        CommandText = query,
                        CommandType = CommandType.Text
                    };

                    FillParameter(command, "p1", obj.Matricula);
                    FillParameter(command, "p2", obj.Nome);
                    FillParameter(command, "p3", obj.Email);
                    FillParameter(command, "p4", obj.Cta365);
                    FillParameter(command, "p5", obj.Cargo);
                    FillParameter(command, "p6", obj.Setor);
                    FillParameter(command, "p7", obj.Gestor);
                    FillParameter(command, "p8", obj.Dtaadm);
                    FillParameter(command, "p9", obj.Dtadem);
                    FillParameter(command, "p10", obj.Statad);
                    FillParameter(command, "p11", obj.Statjira);
                    FillParameter(command, "p12", obj.Statconflu);
                    FillParameter(command, "p13", obj.Statslack);
                    FillParameter(command, "p14", obj.Door);
                    FillParameter(command, "p15", obj.Ponto);
                    FillParameter(command, "p16", obj.Status);
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

        public int Deletar(FuncionarioModel obj)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(_connectionString))
                {

                    string query = $"DELETE FROM [dbo].[Funcionario]" +
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