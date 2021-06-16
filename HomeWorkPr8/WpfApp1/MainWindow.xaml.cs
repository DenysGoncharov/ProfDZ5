using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Тип для Сериализации и Десериализации.
        readonly XmlSerializer serializer = new XmlSerializer(typeof(MyClass));

        MyClass instance1 = new MyClass();
        //MyClass instance2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                instance1.Items.Add("Element " + i); // Заполнение списка.
            }

            FileStream stream = new FileStream("Serialization.xml", FileMode.Create, FileAccess.Write, FileShare.Read);

            // Сохраняем объект в XML-файле на диске(СЕРИАЛИЗАЦИЯ).
            serializer.Serialize(stream, instance1);
            MessageBox.Show("Serialization complit!");
            stream.Close();
        }
    }
}
