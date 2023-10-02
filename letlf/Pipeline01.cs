using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace letlf
{
    internal class Pipeline01
    {
        //a test pipeline





        public static void RunPipeline()
        {
            RefreshViewOnServer();
            RefreshOutputTable();

        }

        private static void RefreshViewOnServer()
        {
            const string viewName = "AW.vGetAllCategories";

            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();
                int r;
                //drop view on server:
                r = new SqlCommand($"DROP VIEW IF EXISTS {viewName}", connection).ExecuteNonQuery();
                Console.WriteLine($"Dropped view {viewName} - {r} rows affected");

                //crate view on server:                
                string viewCodeFullPath = AppPath.GetViewFullPath(viewName);
                string viewSQLCode = File.ReadAllText(viewCodeFullPath);
                r = new SqlCommand(viewSQLCode, connection).ExecuteNonQuery();
                Console.WriteLine($"Created view {viewName} - {r} rows affected");

                connection.Close();
            }
        }


        private static void RefreshOutputTable()
        {
            const string table = "destsys01.letlf_out_test01";

            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();
                int r;
                //drop table on server:
                r = new SqlCommand($"DROP TABLE IF EXISTS {table}", connection).ExecuteNonQuery();
                Console.WriteLine($"Dropped table {table} - {r} rows affected");

                //crate table on server:                
                string tableCodeFullPath = AppPath.GetTableOutputFullPath(table);
                string tableSQLCode = File.ReadAllText(tableCodeFullPath);
                r = new SqlCommand(tableSQLCode, connection).ExecuteNonQuery();
                Console.WriteLine($"Created table {table} - {r} rows affected");

                connection.Close();
            }
        }

    }






}

