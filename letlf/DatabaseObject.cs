using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common; //nuget
using Microsoft.SqlServer.Management.Smo; //nuget



namespace letlf
{
    internal class DatabaseObject
    {
        public static void CreateOrAlterView(string viewName)
        {


            //USING SMO!
            //(see dependecies / nuget for further info..)


            Server srv = new Server(Program.SMO_server); //SMO

            try
            {
                string sqlFilePath = AppPath.GetViewFullPath(viewName);
                string sqlCode = System.IO.File.ReadAllText(sqlFilePath);

                srv.Databases[Program.SMO_dbName].ExecuteNonQuery(sqlCode);

                Console.WriteLine($"Created/updated view {viewName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating/updating view {viewName}: {ex.Message}");
            }
            finally
            {
                srv.ConnectionContext.Disconnect();

            }

        }



        public static void DropAndCreateTable(string table)
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



        public static void CreateOrAlterProcedure(string procName)
        {

            //USING SMO!
            //(see dependecies / nuget for further info..)


            Server srv = new Server(Program.SMO_server); //SMO

            try
            {                
                string sqlFilePath = AppPath.GetProcedureOutputFullPath(procName);
                string sqlCode = System.IO.File.ReadAllText(sqlFilePath);

                srv.Databases[Program.SMO_dbName].ExecuteNonQuery(sqlCode);

                Console.WriteLine($"Created/updated procedure {procName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating/updating procedure {procName}: {ex.Message}");
            }
            finally
            {
                srv.ConnectionContext.Disconnect();

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
