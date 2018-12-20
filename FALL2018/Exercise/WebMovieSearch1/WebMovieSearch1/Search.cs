using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebMovieSearch1
{
    class Search
    { 
        public static Movie Movie = Parse.GetMovie();
        private static SqlConnection connection;
        public static void InsertIntoDB()
        {
            List<string> result = new List<string>();
            string connect_str = "Data Source= (local);Initial Catalog=DataBaseForMovieService; Integrated Security=true";
            using (SqlConnection command = new SqlConnection(connect_str))
            {
                var insert = $"INSERT INTO DataBaseForMovieService.dbo.Movie " +
                    $"(movieName, duration, genre, cinema, movieDescription, Country, Year, Actors) " +
                    $"VALUES ('{Movie.Name}', '{Movie.Duration}', " +
                    $"'{Movie.Genre}', '{Movie.Cinema}', '{ Movie.Description}', " +
                    $"'{ Movie.Country}','{ Movie.Year}', '{ Movie.Actors }');";
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tmp = "\t";
                    for (int i = 0; i < reader.FieldCount; i++)
                        tmp += reader.GetValue(i).ToString() + "\t";
                    result.Add(tmp);
                }
                reader.Close();
                connection.Close();
            }
            
        }
        public static List<string> Connect()
        {
            List<string> result = new List<string>();           
            string connect_str = "Data Source= (local);Initial Catalog=DataBaseForMovieService; Integrated Security=true";
            //string query = "SELECT * FROM WebMovieService.dbo.sysdiagrams WHERE 1 = 1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM DataBaseForMovieService.dbo.Movie";
            try
            {
                connection = new SqlConnection(connect_str);
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string tmp = "\t";
                    for (int i = 0; i < reader.FieldCount; i++)
                        tmp += reader.GetValue(i).ToString() + "\t";
                    result.Add(tmp);
                }
                reader.Close();
                connection.Close();
                InsertIntoDB();
                return result;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        public static bool CheckInjection(string str)
        {
            char semicolon = ';';
            char slash = '\'';
            char hypen = '-';
            bool c = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == semicolon)
                {
                    if (c) { return true; }
                    return false;
                }
                if (str[i] == slash)
                {
                    if (c) { c = false; }
                    else c = true;
                }
                if (i != str.Length - 2 && (str[i] == hypen && str[i + 1] == hypen) || (str[i] == '/' && str[i + 1] == '*'))
                {
                    if (c) { return true; }
                    return false;
                }
            }
            return true;
        }

    }
}