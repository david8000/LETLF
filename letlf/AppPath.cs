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


        public static string GetViewFullPath(string viewName)
        {
            return $@"{SQLviewPath}\{viewName}" + sql;
        }




    }
}
