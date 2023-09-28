using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace letlf
{
    internal class ConnectionTest
    {
        public static void TestConnection(string query)
        {
            using (SqlConnection connection = new SqlConnection(Program.conStr))
            {
                connection.Open();                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();
                        while (reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                s += reader.GetValue(i).ToString();
                                s += i < reader.FieldCount ? "; " : "";
                            }
                            sb.AppendLine(s);
                        }
                        Console.WriteLine(sb.ToString());
                    }
                }
                connection.Close();
            }
        }

        public static bool IsWorking()
        {
            bool result;
            SqlConnection connection = new SqlConnection(Program.conStr);
            try
            {
                connection.Open();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    
    }
}
