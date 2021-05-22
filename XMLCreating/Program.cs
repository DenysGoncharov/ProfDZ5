using System;
using System.Xml;

namespace XMLCreating
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загрузка XML из файла.
            var document = new XmlDocument();
            document.Load("TelephoneBook.xml");

            // Показ содержимого XML.
            Console.WriteLine(document.InnerText);

            Console.WriteLine(new string('-', 20));

            // Показ кода XML документа.
            Console.WriteLine(document.InnerXml);

            Console.WriteLine(new string('*',20)+"\n");

            var reader = new XmlTextReader("TelephoneBook.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Проверка на тип узла необходима, иначе будут найдены не только открывающие элементы (XmlNodeType.Element),
                    // но и закрывающие (XmlNodeType.EndElement).
                    if (reader.Name.Equals("Name"))   // Закомментировать и выполнить.
                    {
                        Console.WriteLine($"|{reader.GetAttribute("TelephoneNumber")}|");
                    }
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
