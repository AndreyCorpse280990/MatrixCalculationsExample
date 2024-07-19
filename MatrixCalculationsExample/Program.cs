using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ЗАДАЧА: реализовать синхронный и параллельный алгоритмы сложения двух матриц чисел
            // протестировать алгоритмы и проанализировать их

            MatrixCalculationsTest.TestSumParallel();
            // MatrixCalculationsTest.TestSumParallel();
        }
    }
}
