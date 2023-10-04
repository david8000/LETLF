using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace letlf
{
    internal class DatabaseObject
    {
        public static void RecreateView(string viewName)
        {


            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();

                //drop view on server:
                new SqlCommand($"DROP VIEW IF EXISTS {viewName}", connection).ExecuteNonQuery();
                Console.WriteLine($"Dropped view {viewName}");

                //crate view on server:                
                string viewCodeFullPath = AppPath.GetViewFullPath(viewName);
                string viewSQLCode = File.ReadAllText(viewCodeFullPath);
                new SqlCommand(viewSQLCode, connection).ExecuteNonQuery();
                Console.WriteLine($"Created view {viewName}");

                connection.Close();
            }

        }


        public static void RecreateTable(string table)
        {

            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();

                //drop table on server:
                new SqlCommand($"DROP TABLE IF EXISTS {table}", connection).ExecuteNonQuery();
                Console.WriteLine($"Dropped table {table}");

                //crate table on server:                
                string tableCodeFullPath = AppPath.GetTableOutputFullPath(table);
                string tableSQLCode = File.ReadAllText(tableCodeFullPath);
                new SqlCommand(tableSQLCode, connection).ExecuteNonQuery();
                Console.WriteLine($"Created table {table}");

                connection.Close();

            }
        }


        public static void RecreateProcedure(string procName)
        {
            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                string sqlFilePath = AppPath.GetProcedureOutputFullPath(procName);
                string sqlCode = File.ReadAllText(sqlFilePath);

                connection.Open();
                int rslt;
                rslt = new SqlCommand($"EXEC {sqlCode}", connection).ExecuteNonQuery();
                Console.WriteLine($"Created/updated procedure {procName}, Result: {rslt}");

                connection.Close();
            }
        }


        public static void ExecuteProcedure(string procName)
        {
            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();
                int rslt;
                rslt = new SqlCommand($"EXEC {procName}", connection).ExecuteNonQuery();
                Console.WriteLine($"EXECUTED procedure {procName}, Result: {rslt}");
                connection.Close();
            }
        }

    }
}
