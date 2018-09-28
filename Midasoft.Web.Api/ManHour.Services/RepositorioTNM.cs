using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManHour.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ManHour.Services
{
    public sealed class RepositorioTNM
    {
        internal static void Agregar(TipoNomina tipoNomina)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            Database db = DatabaseFactory.CreateDatabase();

            using (var command = db.GetStoredProcCommand("crud_TNMInsert"))
            using (command.Connection = db.CreateConnection())
            {
                AddRequiredParameters(tipoNomina, command);
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
            
        }

        private static void AddRequiredParameters(TipoNomina tipoNomina, DbCommand command)
        {
           
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@TIPO_NOM",
                Value = tipoNomina.Tipo
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DESCRIPCION",
                Value = tipoNomina.Descripcion
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@HORS_POR_MES",
                Value = tipoNomina.HorasMes,
                DbType = DbType.Double
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@HRS_DIA",
                Value = tipoNomina.HorasDia,
                DbType = DbType.Double
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DIAS_P",
                Value = tipoNomina.DiasPeriodo,
                DbType = DbType.Double
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DSCTO_MIN",
                Value = tipoNomina.DescuentoMinimo,
                DbType = DbType.Double
            });
        }

        public static IEnumerable<TipoNomina> Find(string tipo)
        {
            List<TipoNomina> recordsTipoNomina = new List<TipoNomina>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            Database db = DatabaseFactory.CreateDatabase();
            using (var command = db.GetStoredProcCommand("crud_TNMSelect"))
            using (command.Connection = db.CreateConnection())
            {

                try
                {
                    if(string.IsNullOrEmpty(tipo))
                        command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@TIPO_NOM",
                            Value =  DBNull.Value 
                        });
                    else
                        command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@TIPO_NOM",
                            Value = tipo
                        });
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //TIPO_NOM, DESCRIPCION, HORS_POR_MES, HRS_DIA, DIAS_P, DSCTO_MIN
                        recordsTipoNomina.Add(
                            new TipoNomina()
                            {
                                Tipo = reader.GetString(0),
                                Descripcion = reader.GetString(1),
                                DiasPeriodo = reader.GetDouble(4),
                                HorasMes = reader.GetDouble(2),
                                HorasDia = reader.GetDouble(3),
                                DescuentoMinimo = reader.GetDouble(5)
                            }
                            );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return recordsTipoNomina;
        }
    }
}
