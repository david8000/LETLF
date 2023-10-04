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
            // (re-) create view
            DatabaseObject.RecreateView("AW.vGetAllCategories");

            // drop and create output table
            string table = "DestSys01.letlf_out_test01";
            DatabaseObject.RecreateTable(table);

            //Update or create procedure
            string proc = "AW.sp_letlf_out_test01";
            DatabaseObject.RecreateProcedure(proc);

            //Execute procedure:
            DatabaseObject.ExecuteProcedure(proc);

            Console.WriteLine($"Result of {proc} is now available in {table}");
            Console.WriteLine($"SELECT * FROM {table}");




        }


    }






}

