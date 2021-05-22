using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private Button button1;
        private ColorDialog chooseColorDialog = new ColorDialog();
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(OnClickChooseColor);
            try
            {
                if (ReadSettings() == false)
                {
                    listBox1.Items.Add("Configrtion file is empty");
                }
                else 
                {
                    listBox1.Items.Add("Configrtion file loaded  sucsesfull");
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
            }
            catch (Exception e)
            {
                listBox1.Items.Add("Something was wrong");
                listBox1.Items.Add(e.Message);
            }

        }
        void OnClickChooseColor(object Sender, EventArgs e)
        {
            if (chooseColorDialog.ShowDialog() == DialogResult.OK)
                listBox1.BackColor = chooseColorDialog.Color;
        }

        void SaveSettings()
        {
            XmlDocument doc = loadConfirmDocment();

            XmlNode node = doc.SelectSingleNode("//appSettings");
            string[] key = new string[] {"BackGroundColor",
                                          "ForeGrooundColor",
                                          "Font",
                                          "Font Stile",
                                          "Font Size"};
            string backColor = ColorTranslator.ToHtml(listBox1.BackColor);


            string[] value = new string[] {backColor,
                                          listBox1.ForeColor.Name.ToString(),
                                          listBox1.Font.Name,
                                          listBox1.Font.Style.ToString(),
                                          listBox1.Font.Size.ToString()};
            for (int i = 0; i < key.Length; i++)
            {
                // Обращаемся к конкретной строке по ключу.
                XmlElement element = node.SelectSingleNode(string.Format($"/add[@key='{key[i]}']")) as XmlElement;

                // Если строка с таким ключем существует - записываем значение.
                if (element != null) { element.SetAttribute("value", value[i]); }
                else
                {
                    // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", key[i]);
                    element.SetAttribute("value", value[i]);
                    node.AppendChild(element);
                }
                doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
            }

        }
        bool ReadSettings()//TODO закончит считывание данных из файла конфигурации
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count < 1) { return false; }

                 
            listBox1.BackColor = ColorTranslator.FromHtml(allAppSettings["BackGroundColor"]);
            
            listBox1.BackColor = ColorTranslator.FromHtml(allAppSettings["ForeGrooundColor"]);
          // listBox1.Font.Name = allAppSettings["Font"];
          // listBox1.Font.Style = allAppSettings["Font Stile"];
          // listBox1.Font.Size= allAppSettings["Font Size"]; ;

            return (true);
        }
        private static XmlDocument loadConfirmDocment()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location+".config");
                return doc;
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("No config file found", e);
            }
        }

       
        //private void button1_Click(object sender, EventArgs e)
        //{
        //
        //    ColorDialog color = new ColorDialog();
        //    if (color.ShowDialog() == DialogResult.OK)
        //    {
        //        listBox1.BackColor = color.Color;
        //        listBox1.Items.Insert(0, "BackGround Color: " + listBox1.BackColor.Name.ToString());
        //        listBox1.Items.Insert(1, "Foreground Color: " + listBox1.ForeColor.Name.ToString());
        //        listBox1.Items.Insert(2, "Font: " +             listBox1.Font.Name);
        //        listBox1.Items.Insert(3, "Font Stile: "+        listBox1.Font.Style.ToString());
        //        listBox1.Items.Insert(4, "Font Size: " +        listBox1.Font.Size.ToString());
        //    }
        //}
    }
}
