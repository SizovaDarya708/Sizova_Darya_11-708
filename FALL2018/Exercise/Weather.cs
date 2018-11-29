﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;


namespace Wether
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your city...");
            string city = Convert.ToString(Console.ReadLine());

            Wether(city);
            Console.ReadKey();
        }

        public static void Wether(string city)
        {
            var url = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather." +
                "forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text" +
                "%3D%22" + city +
                "%22)&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
            // Создание клиента
            WebClient Client = new WebClient();
            Client.Encoding = Encoding.UTF8;
            //Данные с сайта
            var downloadInfo = Client.DownloadString(url);
            if (downloadInfo == null)
            {
                throw new ArgumentNullException();
            }
            string[] dates = downloadInfo.Split('<');
            string result = dates[45];
            dates = result.Split('=');
            result = dates[4];
            dates = result.Split('"');
            result = dates[1];
            var temperature = Convert.ToInt16(result);

            Console.WriteLine("The temperature in your city is " + temperature);     
        }
    }
}