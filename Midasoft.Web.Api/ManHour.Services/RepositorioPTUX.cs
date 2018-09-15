using System;
using System.Collections.Generic;
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
            try
            {
                DatabaseManager.ExecuteStoredProcedure("PTUXInsert", AddRequiredParameters(actividad));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return true ;
        }

        internal static IEnumerable<Actividad> Obtener(int? id)
        {
            List<Actividad> actividades = new List<Actividad>();
            object parameterValue;
            if (id.HasValue)
                parameterValue = id.Value;
            else
                parameterValue =  DBNull.Value;
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@CNSPTUX",
                        Value = parameterValue
                    }
                };
            
            return DatabaseManager.ExecuteStoredProcedureReader<Actividad>("PTUXSelect", parameters,MapActivities);
        }

        private static List<Actividad> MapActivities(DbDataReader reader)
        {
            List<Actividad> actividades = new List<Actividad>();
            while (reader.Read())
            {
                actividades.Add(MapReaderRow(reader));
            }
            return actividades;
        }

        private static Actividad MapReaderRow(DbDataReader reader)
        {
            return new Actividad
            {
                CentroCosto = reader.GetValue(3) == DBNull.Value ? null : reader.GetString(3),
                CodigoEmpleado = reader.GetValue(1) == DBNull.Value ? null : reader.GetString(1),
                Id = reader.GetInt32(0),
                Compania = reader.GetValue(14) == DBNull.Value ? null :  reader.GetString(14),
                Contrato = reader.GetValue(15) == DBNull.Value ? null:  reader.GetString(15),
                Directorio = reader.GetValue(9) == DBNull.Value ? null : reader.GetString(9),
                Dispositivo = reader.GetValue(13) == DBNull.Value ? null :  reader.GetString(13),
                FechaMarcacion = reader.GetValue(10) == DBNull.Value ? DateTime.MinValue :  reader.GetDateTime(10),
                FechaProgramada= reader.GetValue(2) == DBNull.Value ? DateTime.MinValue : reader.GetDateTime(2),
                Horario = reader.GetValue(8) == DBNull.Value ? null : reader.GetString(8),
                Novedad = reader.GetValue(11) == DBNull.Value ? null :  reader.GetString(11),
                Observacion = reader.GetValue(12) == DBNull.Value ? null :  reader.GetString(12),
                TipoMovimiento = reader.GetValue(4) == DBNull.Value ? null :  reader.GetString(4),
                TipoRegistro = reader.GetValue(7) == DBNull.Value ? null :  reader.GetString(7),
                UsuarioAutoriza = reader.GetValue(5) == DBNull.Value ? null : reader.GetString(5),
                UsuarioRegistro = reader.GetValue(6) == DBNull.Value ? null :  reader.GetString(6)
            };
        }

        private static SqlParameter[] AddRequiredParameters(Actividad actividad)
	    {
            return new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@EMPLEADO",
                        Value = actividad.CodigoEmpleado
                    },
                    new SqlParameter
                    {
                        ParameterName = "@USUARIOAUT",
                        Value = actividad.UsuarioAutoriza,
                    },
                    new SqlParameter
                    {
                        ParameterName = "@USUARIO",
                        Value = actividad.UsuarioRegistro,
                    },
                    new SqlParameter
                    {
                        ParameterName = "@TIPO_REG",
                        Value = DBNull.Value,
                    },
                    new SqlParameter
                    {
                        ParameterName = "@FCH_REAL_MARC",
                        Value = actividad.FechaMarcacion,
                    },
                    new SqlParameter
                    {
                        ParameterName = "@NOVEDAD",
                        Value = DBNull.Value,
                    },
                    new SqlParameter
                    {
                        ParameterName = "@IP",
                        Value = actividad.Dispositivo,
                    }
                };
	    }

	    public static bool Actualizar(Actividad actividad)
	    {
           
            var insert_params = AddRequiredParameters(actividad);
            Array.Resize<SqlParameter>(ref insert_params, insert_params.Length + 1);
            insert_params[insert_params.Length - 1] = new SqlParameter
            {
                ParameterName = "@CNSPTUX",
                Value = actividad.Id
            };
            try
            {
                DatabaseManager.ExecuteStoredProcedure("PTUXUpdate", insert_params);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return true;
           
        }

        public static bool Borrar(int idActividad)
        {
            DbParameter[] delete_params = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@CNSPTUX",
                        Value = idActividad
                    }
                };
            DatabaseManager.ExecuteStoredProcedure("PTUXDelete", delete_params);
            return true;
        }
	   
    }
}
