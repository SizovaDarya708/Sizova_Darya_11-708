using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.Collections;
// пока реализовала без sql-инъекций
namespace WebSerDB
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class DataBaseWebService : WebService
    {
        // Устанавливаем соединение
        public static string connectStr = ConfigurationManager
            .ConnectionStrings["DataBaseConnection"]
            .ConnectionString;
        //Получаем таблицы
        [WebMethod]
        public List<string> GetTable()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                // получаем схему определенной таблицы
                DataTable table = connection.GetSchema("Table");
                foreach (Data row in table.Rows)
                {
                    //добавления строки таблицы
                    result.Add(row[2].ToString());
                }
                return result;
            }
        }
        //получение столбца 
        [WebMethod]
        public List<string> GetColumn(string table)
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                Console.WriteLine();
                var select = ("SELECT * FROM " + table);
                SqlCommand command = new SqlCommand(select, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                for (int i = 0; i < count; i++)
                {
                    result.Add(reader.GetName(i));
                }
                return result;
            }
        }
        // получение значений
        [WebMethod]
        public List<string> GetValues(string tablename, string condition)
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                var select = "SELECT * FROM " + tablename + " WHERE " + condition;
                SqlCommand command = new SqlCommand(select, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        result.Add(reader[i].ToString());
                    }
                }
                reader.Close();
            }
        }
    }
}
