using System;
using System.Text;
using System.Threading;

namespace MutexExersise
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "MySecretMutex");

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Name = i.ToString();
                Thread.Sleep(500); // Потоки из разных процессов успеют стать в очередь вперемешку.
                threads[i].Start();
            }

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            mutex.WaitOne();

            Console.WriteLine($"Thread {Thread.CurrentThread.Name} entered the protected area.");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} has left the protected area.\n");

            mutex.ReleaseMutex();
        }
    }
}
