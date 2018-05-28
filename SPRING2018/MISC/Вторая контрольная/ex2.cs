using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace ex._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //нашла в интернете этот тип для простой работы
            JavaScriptSerializer json = new JavaScriptSerializer();
            // Лист obj, в котором хранятся данные
            String dataString;
            int a = 0; //  количество
            List<object> listOfData = new List<object>() { new MyClass() };
            List<char> symbols = new List<char> { 'b', 'c', 'd', 'f', 'j', 'k', 'l',
                'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'
            };
            
            
            for (int i = 0; i < listOfData.Count; i++)
            {
                // получаем тип 
                Type type = listOfData[i].GetType();
                // информацию о методе
                MethodInfo[] methodInfo = type.GetMethods();
                // работа в цикле
                for (int j = 0; j < methodInfo.Length; j++)
                {
                    a = 0;
                    // Для больших и маленьких букв
                    dataString = methodInfo[j].Name.ToLower();

                    for (int n = 0; n < dataString.Length; n++)
                    {
                        for (int m = 0; m < symbols.Count; m++)
                        {
                            if (dataString[n] == symbols[m])
                                a++;
                        }
                    }
                    if (a % 2 != 1)
                    {
                        Console.WriteLine(methodInfo[j].Name.ToString());
                        // преобразование в строку
                        json.Serialize(methodInfo[j].Name.ToString());
                    }
                }
            }

            Console.ReadKey();

        }
    }
    // "какой-то" класс для работы с ним
    public class MyClass
    {
        public int Method(int argument)
        {
            return argument + 1;
        }
        public double Property { get; set; }
    }
}

