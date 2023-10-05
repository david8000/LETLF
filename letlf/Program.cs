using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace letlf
{
    internal class Program
    {

        // *****************************************************************************
        // APP SETTINGS - WE CURRENTLY STORE THEM HERE :)

        //Connection string to ETL database:
        //(SQL Server is assumed)
        public const string conStr = @"Server=.\SQLEXPRESS;Database=ETL;Integrated Security=True;";
        // Parameters for "SMO" - see dependencies / nuget:
        public const string SMO_server= @".\SQLEXPRESS";
        public const string SMO_dbName = "ETL";
        // *****************************************************************************

        static void Main(string[] args)
        {
            //Try a connection test:
            /*
            Console.WriteLine($"Working: {ConnectionTest.IsWorking()}");
            ConnectionTest.TestConnection("SELECT TOP 7 * FROM [SourceDataAdventureWorks].[Customer]");

            //SMO connection test not yet implemented (231004). 
            */


            //This will run an "ETL job". Define as many as you like for running difference scenarios.
            Pipeline01.RunPipeline();

            
        }
        // *****************************************************************************





    } //class
}