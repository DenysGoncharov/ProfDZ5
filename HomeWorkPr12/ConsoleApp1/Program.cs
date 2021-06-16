using System;
using System.Threading;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }

            Console.ReadLine();
        }
    }

    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Reader {i.ToString()}";
            myThread.Start();
        }

        public void Read()
        {            
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} come in to the library");
                FileStream file = File.Open(@"D:\1\1.log", FileMode.Append, FileAccess.Write, FileShare.Write);
                var writer = new StreamWriter(file);
                writer.WriteLine($"{Thread.CurrentThread.Name} come in to the library " + DateTime.Now);
                writer.Close();
                file.Close();
                Console.WriteLine($"{Thread.CurrentThread.Name} reading");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} leave library");

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
