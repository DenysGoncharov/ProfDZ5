using System;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        // Тип для Сериализации и Десериализации.
        readonly XmlSerializer serializer = new XmlSerializer(typeof(MyClass));

        

        static void Main(string[] args)
        {
            MyClass instance1 = new MyClass();
            MyClass instance2;
            for (int i = 0; i < 10; i++)
            {
                instance1.Items.Add("Element " + i); // Заполнение списка.
            }

            FileStream stream = new FileStream("Serialization.xml", FileMode.Create, FileAccess.Write, FileShare.Read);

            // Сохраняем объект в XML-файле на диске(СЕРИАЛИЗАЦИЯ).
            serializer.Serialize(stream, instance1);
            this.Text = "Объект сериализован!";
            stream.Close();
            //Deserialisation
            FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

            // Восстанавливаем объект из XML-файла.
            instance2 = serializer.Deserialize(stream) as MyClass;
            this.Text = "Объект Десериализован!";


            textBox.Text = "ID        : " + instance2.ID + Environment.NewLine +
                            "Size     : " + instance2.Size + Environment.NewLine +
                            "Position : " + instance2.Position.ToString() + Environment.NewLine +
                            "List     : " + Environment.NewLine;

            foreach (string item in instance2.Items)
            {
                textBox.Text += "\t" + item + Environment.NewLine;
            }

            textBox.Text += "Password: " + instance2.Password;
            stream.Close();
        }
    }
}
