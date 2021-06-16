using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Тип для Сериализации и Десериализации.
       readonly XmlSerializer serializer = new XmlSerializer(typeof(MyClass));

        //MyClass instance1 = new MyClass();
        MyClass instance2;
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //адресс файла для сериализации
                string fileName = @"C:\Users\kate\source\repos\Professional\HomeWorkPr8\WpfApp1\bin\Debug\net5.0-windows\Serialization.xml";
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Восстанавливаем объект из XML-файла.
                instance2 = serializer.Deserialize(stream) as MyClass;
                this.Text = "Deserialize complite!";


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
}
