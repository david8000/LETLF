using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace letlf
{
    internal class Pipeline01
    {
        //a test pipeline





        public static void RunPipeline()
        {
            RefreshViewOnServer();
        }

        private static void RefreshViewOnServer()
        {
            //read view code
            string viewCode = System.IO.File.ReadAllText(@".\SQL.\view\[SourceDataAdventureWorks].[vGetAllCategories].sql");
            const string viewName = @"[SourceDataAdventureWorks].[vGetAllCategories]";

            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                int r;
                //drop view on server:
                r = new SqlCommand($"DROP VIEW IF EXISTS {viewName}", connection).ExecuteNonQuery();
                Console.WriteLine($"Dropped view {viewName} - {r} rows affected");

                //crate view on server:
                r = new SqlCommand(viewCode, connection).ExecuteNonQuery();
                Console.WriteLine($"Created view {viewName} - {r} rows affected");

            }

        }




    }
}
