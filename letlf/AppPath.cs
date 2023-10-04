using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace letlf
{
    internal class AppPath
    {
        const string sql = @".sql"; 

        public static string ExePath
        {
            get { return Path.GetFullPath(AppContext.BaseDirectory); }
        }


        public static string SQLbasePath
        {
            get { return Path.Combine(ExePath, "SQL"); }
        }

        public static string SQLviewPath
        {
            get { return Path.Combine(SQLbasePath, "view"); }
        }

        public static string SQLtableOutputPath
        {
            get { return Path.Combine(SQLbasePath, "table_output"); }
        }

        public static string SQLprocedureOutputPath
        {
            get { return Path.Combine(SQLbasePath, "proc_output"); }
        }



        //***
        //Full paths to files:

        public static string GetViewFullPath(string viewName)
        {
            return $@"{SQLviewPath}\{viewName}" + sql;
        }

        public static string GetTableOutputFullPath(string table)
        {
            return $@"{SQLtableOutputPath}\{table}" + sql;
        }

        public static string GetProcedureOutputFullPath(string procedure)
        {
            return $@"{SQLprocedureOutputPath}\{procedure}" + sql;
        }


    }
}
