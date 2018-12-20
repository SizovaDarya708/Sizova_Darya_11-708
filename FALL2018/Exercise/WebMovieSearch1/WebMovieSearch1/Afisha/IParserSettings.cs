using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMovieSearch1.Afisha
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }//Содержит Url сайта для парсинга
        string Prefix { get; set; }
        int StartPoint { get; set; }//Указывает на страницы для парсинга
        int EndPoint { get; set; }//Конечный индекс страницы для парсинга

    }
}
