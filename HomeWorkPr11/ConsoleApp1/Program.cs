using System;
using System.Threading;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        
        public static void ReadStream(string name, out string line)
	    {

            string fileName = $"D:\\1\\{name}.txt";
        // Открываем файл для чтения.
            FileStream file = File.Open(fileName, FileMode.Open, FileAccess.Read);

            // Создаем поток для чтения данных из файла.
            StreamReader reader = new StreamReader(file);

            // Читаем до конца.
            line = reader.ReadToEnd();
	    		
	    		// Закрываем файл и удаляем поток.
	    		reader.Close();
            
	    }
        
        public static void WriteStream(ref string line)
        {
            // Создание файла.
            
            FileStream file = File.Open(@"D:\1\3.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            var writer = new StreamWriter(file);
                 writer.WriteLine(line);
                 writer.Close();
                 file.Close();
        }
        public class MyThread
        {
            public Thread Thrd;
            string line;
            public MyThread(string name)
            {

                Thrd = new Thread(this.Run);
                Thrd.Name = name;
                Thrd.Start();
            }
            void Run()
            {
                Console.WriteLine(Thrd.Name + "started");
                ReadStream(Thrd.Name, out line);

                WriteStream(ref line);
                Console.WriteLine(Thrd.Name + "is over");
            }
        }

        static void Main(string[] args)
         {
            MyThread mt1 = new MyThread("1");
            MyThread mt2 = new MyThread("2");
            mt1.Thrd.Join();
            mt2.Thrd.Join();
        }
    }
}
