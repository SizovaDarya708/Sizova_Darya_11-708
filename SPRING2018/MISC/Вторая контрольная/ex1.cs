using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ex._1
{
    /*По адресу https://jsonplaceholder.typicode.com/photos получить список картинок в виде json.
     * Реализовать скачивание картинок по адресу thumbnailUrl. 
     * Использовать максимально все технологии, которые вы знаете: 
     * многопоточное или асинхронное программирование, linq и т.д. 
     * Парсер json можно использовать библиотечный. */
    class Program
    {
        
        static void Main(string[] args)
        {
             var listOfData = new List<object> { };

            /* string url = "https://jsonplaceholder.typicode.com/photos";
             using (WebClient client = new WebClient())
             {
                 client.DownloadFile(url, AppDomain.CurrentDomain.BaseDirectory + "test.jpg");
                 listOfData.Add(url);
             }*/

            WebClient webClient = new WebClient();
            WebClient url = new WebClient();

            var data = url.DownloadString("https://jsonplaceholder.typicode.com/photos");
            JObject o = JObject.Parse(data);

            var json = JsonConvert.SerializeObject(listOfData, Formatting.Indented);
      
            foreach (var field in listOfData)
            {
                listOfData.Add(field.ToString());
            }
            Console.ReadKey();
        }
    }
}
