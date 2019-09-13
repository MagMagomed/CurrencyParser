using System;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;


namespace CurrencyParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            
            XmlDocument weatherURL = new XmlDocument();
            weatherURL.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019");
            string str = weatherURL.InnerXml;
           
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
                str = str.Substring(45);
                string a = str;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "XMLToTable";
                SqlParameter XML = new SqlParameter("@x",a);
                cmd.Parameters.Add(XML);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }

            Console.Read();
            
        }
    }
}
