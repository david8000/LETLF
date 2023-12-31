﻿using System;
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
            DatabaseObject.CreateOrAlterView("AW.vGetAllCategories");

            // drop and create output table
            string table = "DestSys01.letlf_out_test01";
            DatabaseObject.DropAndCreateTable(table);

            //Update or create procedure
            string proc = "AW.sp_letlf_out_test01";
            DatabaseObject.CreateOrAlterProcedure(proc);

            //Execute procedure:
            DatabaseObject.ExecuteProcedure(proc);

            Console.WriteLine("");
            Console.WriteLine($"Result of {proc} is now available in {table}");
            Console.WriteLine("Try..");
            Console.WriteLine($"SELECT * FROM {table}");




        }


    }






}

