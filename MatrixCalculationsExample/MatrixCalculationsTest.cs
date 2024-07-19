using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    // MatrixCalculationsTest - класс для тестирование алгоритмов матричных вычислений
    internal static class MatrixCalculationsTest
    {
        // TestSum - тестирование синхронного суммирования
        public static void TestSum()
        {
            // 1. ввод исходных данных
            Console.Write("Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int min = 0, max = 4;

            // 2. подготовка матриц
            Random random = new Random();
            int[][] m1 = MatrixHelper.GenerateRandom(m, n, min, max, random);
            int[][] m2 = MatrixHelper.GenerateRandom(m, n, min, max, random);
            int[][] result = MatrixHelper.CreateEmpty(m, n);
            Console.WriteLine("m1, m2 generated; result created");

            // 3. выполнение операции
            Stopwatch sw = Stopwatch.StartNew();    
            MatrixCalculations.Sum(m1, m2, result);
            sw.Stop();

            // 4. вывод результата
            Console.WriteLine($"Sum completed, elapsed {sw.ElapsedMilliseconds} ms.");
            Console.Write("Do you want to print matrices? (y / n)");
            char reply = Console.ReadKey(true).KeyChar;
            Console.WriteLine();
            if ("yYнН".Contains(reply))
            {
                MatrixHelper.Print(m1, "m1:");
                MatrixHelper.Print(m2, "m2:");
                MatrixHelper.Print(result, "result:");
            }
        }

        // TestSumParallel - тестирование параллельного алгоритма
        public static void TestSumParallel()
        {
            // 1. ввод исходных данных
            Console.Write("Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter k: ");
            int k = Convert.ToInt32(Console.ReadLine());
            int min = 0, max = 4;

            // 2. подготовка матриц
            Random random = new Random();
            int[][] m1 = MatrixHelper.GenerateRandom(m, n, min, max, random);
            int[][] m2 = MatrixHelper.GenerateRandom(m, n, min, max, random);
            int[][] result = MatrixHelper.CreateEmpty(m, n);
            Console.WriteLine("m1, m2 generated; result created");

            // 3. выполнение операции
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.SumParallel(m1, m2, result, k);
            sw.Stop();

            // 4. вывод результата
            Console.WriteLine($"SumParallel completed, elapsed {sw.ElapsedMilliseconds} ms.");
            Console.Write("Do you want to print matrices? (y / n)");
            char reply = Console.ReadKey(true).KeyChar;
            Console.WriteLine();
            if ("yYнН".Contains(reply))
            {
                MatrixHelper.Print(m1, "m1:");
                MatrixHelper.Print(m2, "m2:");
                MatrixHelper.Print(result, "result:");
            }
        }



        // TestSums - сравнение результатов двух алгоритмов
        public static void TestSums()
        {
            throw new NotImplementedException();
        }
    }
}
