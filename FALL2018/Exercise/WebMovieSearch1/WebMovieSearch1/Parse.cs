using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebMovieSearch1
{
    public class Parse
    {
        //public static string Afisha(string filmName)
        //{
        //    if (filmName == null) return null;
        //    //StreamReader reader = new StreamReader("C:/Users/darya/source/repos/JsonTest/JsonTest/testsait.dash");
        //    //string responce = "";
        //    //using (reader)
        //    //{
        //    //    while (!reader.EndOfStream)
        //    //        responce += reader.ReadLine();
        //    //}
        //    //responce = wc.DownloadString("https://afisha.yandex.ru/kazan/selections/cinema-today");
        //    //string rate = System.Text.RegularExpressions.Regex.Match(responce, @"^<div class=""event\w*" + filmName + @"\w*</div>&").Groups[1].Value;
        //    GenreFilter(ref responce, filmName);
        //    GenreFilter(ref responce, filmName);
        //    //return rate;
        //}
        
        public static Movie GetMovie()
        {
            StreamReader reader = new StreamReader("C:/Users/darya/source/repos/JsonTest/JsonTest/testsait.dash");
            string responce = "";
            using (reader)
            {
                while (!reader.EndOfStream)
                    responce += reader.ReadLine();
            }
            string url = Filter("href = \"", "\" data-stat=", responce);
            // Продолжительность
            string duration = Filter("event-attributes__category-value\">", "</dd>", url);
            // Актеры
            string actors = Filter(" data-bem=\"{ &quot; link & quot;:{ } }\">", "</a>", url);
            // Год
            string year = Filter("event-attributes__category-value\">", "</dd>", url);
            // Страна
            string country = Filter("event-attributes__category-value\">", "</dd >", url);
            // получение имени
            string name = Filter("event__name\">", "</h2>", responce);
            // Фильтр для поиска жанра
            string genre = Filter("event__formats\">", "</div>", responce);
            // получение описания
            string description = Filter("event__argument\">", "</div>", responce);
            // кинотеатры
            string cinema = Filter("event__place-name\">", "</span></div>", responce);
            Movie movie = new Movie
            {
                Name = name,
                Duration = duration,
                Genre = genre,
                Cinema = cinema,
                Description = description,
                Country = country,
                Year = year,
                Actors = actors
            };
 
            return movie;        
        }

        public static string Filter(string start, string end, string responce)
        {
            int namestart = responce.IndexOf(start);
            int nameend = responce.IndexOf(end, namestart);
            namestart += start.Length;
            string name = responce.Substring(namestart, nameend - namestart);
            responce = responce.Substring(nameend);
            return name;
        }
    }
}