using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            Console.WriteLine("Enter size of array:");
            int s = int.Parse(Console.ReadLine());
            int[] array = new int[s];

            // Инициализация массива данных положительными значениями.
            Parallel.For(0, s, (i) => array[i] = r.Next(0, 999));

            
            // Запрос PLINQ для поиска отрицательных значений.
            ParallelQuery<int> evenNumbers = from element in array.AsParallel()
                                           where element % 2 == 0
                                           select element;

            foreach (int element in evenNumbers)
                Console.Write(element + " ");

            // Delay
            Console.ReadKey();
        }
    }
}
