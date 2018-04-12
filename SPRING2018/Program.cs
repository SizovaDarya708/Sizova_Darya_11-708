using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Var3
{
    
        /*3. Даны последовательности B, D и E, включающие следующие поля:
         * B: <Страна-производитель> <Артикул товара> <Категория>
           D: <Цена (в рублях)> <Название магазина> <Артикул товара>
            E: <Название магазина> <Артикул товара> <Код потребителя>
        Свойства последовательностей описаны в преамбуле. Для каждого магазина, 
        указанного в E, и каждой страны-производителя определить суммарную
        стоимость товаров из данной страны, проданных в данном магазине 
        (вначале выводится название магазина, затем название страны, затем суммарная стоимость).
        Если для некоторой пары «магазин–страна» отсутствует информация о проданных товарах, 
        то в качестве суммарной стоимости выводится 0. 
        Сведения о каждой паре «магазин–страна» выводить на новой строке
        и упорядочивать по названиям магазинов в алфавитном порядке, а для одинаковых названий магазинов 
        — по названиям стран (также в алфавитном порядке).*/
        public class B
        {
            public string ManufacturerCountry { get; set; } // Страна- производитель
            public string ArticleNumber { get; set; } // Артикул товара
            public string Category { get; set; } // Категория

            public B(string manufacturerCountry, string article, string category)
            {
                ManufacturerCountry = manufacturerCountry;
                ArticleNumber = article;
                Category = category;
            }
        }
        public class D
        {
            public int Cost { get; set; } // Цена
            public string ShopNames { get; set; } // Название магазина
            public string Article { get; set; } // Артикул товара

            public D(int cost, string shopNames, string article)
            {
                Cost = cost;
                ShopNames = shopNames;
                Article = article;
            }
        }
        public class E
        {
            public string ShopNames { get; set; } // Название магазина
            public int Article { get; set; } // Артикул товара
            public int ShoperId { get; set; } // Код потребителя

            public E(string shopNames, int article, int shoperId)
            {
                ShopNames = shopNames;
                Article = article;
                ShoperId = shoperId;
            }
        }
    class Program
    {

        static IEnumerable<char> GetCharCollection(IEnumerable<string> strings)
        {
            return strings.Select(str => str[0])
                .Reverse();
        }


        static IEnumerable<Tuple<string, int, int>> TotalCostOfGoods(IEnumerable<E> shopNames, IEnumerable<B> manufacturerCountry)
        {//вначале выводится название магазина, затем название страны, затем суммарная стоимость
            return shopNames
                 .GroupBy(shop => shop.ShopNames)
                 .Select(shop

        }
        static void Main(string[] args)
        {
        }
    }
}
