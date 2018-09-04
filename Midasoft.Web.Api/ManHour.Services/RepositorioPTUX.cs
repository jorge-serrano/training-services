using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ManHour.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ManHour.Services
{
    /// <summary>
    /// los comentarios aqui
    /// 
    /// </summary>
    public class RepositorioPTUX
    {
        public static bool Insertar(Actividad actividad)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            Database db = DatabaseFactory.CreateDatabase();

            using (var command = db.GetStoredProcCommand("PTUXInsert"))
            using (command.Connection = db.CreateConnection())
            {
                AddRequiredParameters(actividad, command);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
	        
            
            
            
            return true;
        }

	    private static void AddRequiredParameters(Actividad actividad, DbCommand command)
	    {
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@EMPLEADO",
			    Value = actividad.CodigoEmpleado
		    });


		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@USUARIOAUT",
			    Value = actividad.UsuarioAutoriza,
		    });
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@USUARIO",
			    Value = actividad.UsuarioRegistro,
		    });
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@TIPO_REG",
			    Value = DBNull.Value,
		    });
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@FCH_REAL_MARC",
			    Value = actividad.FechaMarcacion,
		    });
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@NOVEDAD",
			    Value = DBNull.Value,
		    });
		    command.Parameters.Add(new SqlParameter
		    {
			    ParameterName = "@IP",
			    Value = actividad.Dispositivo,
		    });
	    }

	    public static bool Actualizar(Actividad actividad)
	    {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            Database db = DatabaseFactory.CreateDatabase();

            using (var command = db.GetStoredProcCommand("PTUXUpdate"))
            using (command.Connection = db.CreateConnection())
            {
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@CNSPTUX",
                    Value = actividad.Id
                });
                AddRequiredParameters(actividad, command);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            return true;
           
        }


	    public static bool InsertarOld(Actividad actividad)
        {
            var connection = new SqlConnection("Data Source=.;Initial Catalog=ManHour;Integrated Security=True");
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PTUXInsert";
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@EMPLEADO",
                Value = actividad.CodigoEmpleado
            });
            /*
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@FCH_PRG",
                Value = actividad.FechaProgramada,

            });
            
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@CCOSTO",
                Value = actividad.CentroCosto,

            });
            */

            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@USUARIOAUT",
                Value = actividad.UsuarioAutoriza,

            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@USUARIO",
                Value = actividad.UsuarioRegistro,

            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@TIPO_REG",
                Value = DBNull.Value,

            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@FCH_REAL_MARC",
                Value = actividad.FechaMarcacion,

            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@NOVEDAD",
                Value = DBNull.Value,

            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IP",
                Value = actividad.Dispositivo,

            });
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Dispose();
            }

            return true;
        }
    }
}
