using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    // XmlRoot - Переименовывает корневой узел.
    [XmlRoot("MyButton")]
    public class MyClass
    {
        private string id = "button";
        private int size = 10;
        private Point position = new Point(20, 30);
        private string password = "1234567890_password";
        private List<string> items = new List<string>();


        // XML атрибут переименовываем и делаем атрибутом.
        [XmlAttribute("SerialID")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        //XML атрибут.
        [XmlAttribute("Length")]
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        //XML элемент.
        [XmlElement("Pos")]
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        // Исключаем свойство из процесса сериализации/десериализации.
        [XmlIgnore]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // Характеристика массива.
        [XmlArray("List")]
        // Характеристика каждого элемента массива.
        [XmlArrayItem("Element")]
        public List<string> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
    class Point
    {
        private int x;
        private int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
