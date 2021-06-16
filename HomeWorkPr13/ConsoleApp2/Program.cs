using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void MyTask1()
        {
            Console.WriteLine("MyTask1: is start");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("+");
            }
            Console.WriteLine("MyTask1: is over");
        }

        static void MyTask2()
        {
            Console.WriteLine("MyTask2: is start");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("-");
            }
            Console.WriteLine("MyTask2: is over");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("main thread is start.");

            ParallelOptions options = new ParallelOptions();

            // Выделить определенное количество процессорных ядер.
            //options.MaxDegreeOfParallelism = Environment.ProcessorCount > 2
            //                          ? Environment.ProcessorCount - 1 : 1;

            options.MaxDegreeOfParallelism = 2; 

            Console.WriteLine("Number of logical CPU cores CPU:" + Environment.ProcessorCount);

            Console.ReadKey();

            // Выполнить параллельно два метода.
            Parallel.Invoke(options, MyTask1, MyTask2);

            

            // ВНИМАНИЕ!???
            // Выполнение метода Main() приостанавливается, 
            // пока не произойдет завершение задач.

            Console.WriteLine("main thread is over.");
           
            // Delay
            Console.ReadKey();
        }
    }
}
