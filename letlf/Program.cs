using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace letlf
{
    internal class Program
    {
        //Connection string to ETL database:
        //(SQL Server is assumed)
        public const string conStr = @"Server=.\SQLEXPRESS;Database=ETL;Integrated Security=True;";
        static void Main(string[] args)
        {
            //Try a connection test:
            /*
            Console.WriteLine($"Working: {ConnectionTest.IsWorking()}");
            ConnectionTest.TestConnection("SELECT TOP 7 * FROM [SourceDataAdventureWorks].[Customer]");
            */


            Pipeline01.RunPipeline();




        }







    } //class
}