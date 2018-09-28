using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManHour.Services
{
    internal class DatabaseManager
    {
        public static int ExecuteStoredProcedure(string spName, DbParameter[] parameters)
        {
            Database db = CreateDatabase();
            using (var command = db.GetStoredProcCommand(spName))
            using (command.Connection = db.CreateConnection())
            {
                AddParameters(command, parameters);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }

        }

        public static IEnumerable<T> ExecuteStoredProcedureReader<T>(string spName, DbParameter[] parameters, Func<DbDataReader,IEnumerable<T>> assignationFucntion)
        {
            Database db = CreateDatabase();
            using (var command = db.GetStoredProcCommand(spName))
            using (command.Connection = db.CreateConnection())
            {
                AddParameters(command, parameters);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                return assignationFucntion.Invoke(reader);
            }
        }

        private static Database CreateDatabase()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            Database db = DatabaseFactory.CreateDatabase();
            return db;
        }

        private static void AddParameters(DbCommand command, DbParameter[] parameters)
        {
            foreach (DbParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }
    }
}
