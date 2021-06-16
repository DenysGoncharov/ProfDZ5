using System;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        
        public static int sum;
        class SumArray
        {
          
            public int SumIt()
            {                            
                for (int i = 0; i < 10; i++)
                {
                    sum++;
                    Console.WriteLine("Current Sum for thread " + Thread.CurrentThread.Name + "is " + sum);
                    Thread.Sleep(100);
                }
                
                return sum;
            }
        }
        class MyThread
        {
            public Thread Thrd;
            
            int answer;
            static SumArray sa = new SumArray();
            public MyThread(string name)
            {
               
                Thrd = new Thread(this.Run);
                Thrd.Name = name;
                Thrd.Start();
            }
            void Run()
            {
                Console.WriteLine(Thrd.Name + "started");
                lock (sa) { answer = sa.SumIt(); }
                Console.WriteLine("Sum for thread " + Thrd.Name + "is " + answer);
                Console.WriteLine(Thrd.Name + "is over");
            }
        }
        static void Main(string[] args)
        {
           
            MyThread mt1 = new MyThread("#1");
            MyThread mt2 = new MyThread("#2");
            MyThread mt3 = new MyThread("#3");

            mt1.Thrd.Join();
            mt2.Thrd.Join();
            mt3.Thrd.Join();
        }
    }
}
