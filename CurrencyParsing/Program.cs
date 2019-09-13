using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace CurrencyParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            /*
            String URLString = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019";
            XmlTextReader reader = new XmlTextReader(URLString);
            StringBuilder xmlstring = new StringBuilder();
            */
            XmlDocument weatherURL = new XmlDocument();
            weatherURL.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019");
            string str = weatherURL.InnerXml;
            //reader.ReadContentAsString();
            /*while (reader.Read())
            {
                
                    Console.WriteLine(reader.Value);

                // Здесь выполняются необходимые действия с данными
                //Console.WriteLine(reader.Value);
            }
            Console.ReadLine();
            
            */
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
            /**/
        }
    }
}
