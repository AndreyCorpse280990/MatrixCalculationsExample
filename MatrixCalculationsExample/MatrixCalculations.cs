using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    // MatrixCalculations - класс, включащий процедуры матричных вычислений
    internal static class MatrixCalculations
    {
        // Sum - процедура поэлементного сложения двух матриц
        // вход: m1, m2 - матрицы для сложения
        // выход: сумма матриц в result (возврат через параметр-массив, память под который выделена снаружи)
        public static void Sum(int[][] m1, int[][] m2, int[][] result)
        {
            for (int i = 0; i < m1.Length; i++)
            {
                for (int j = 0; j < m1[i].Length; j++)
                {
                    result[i][j] = m1[i][j] + m2[i][j];
                }
            }
        }

        // SumParallel - процедура поэлементного сложения двух матриц с распараллеливанием
        // вход: m1, m2 - матрицы для сложения; n - кол-во потоков, на которые надо распараллелить
        // выход: сумма матриц в result (возврат через параметр-массив, память под который выделена снаружи)
        public static void SumParallel(int[][] m1, int[][] m2, int[][] result, int threadCount)
        {
            int rows = m1.Length;
            int rowsThread = rows / threadCount;
            Thread[] threads = new Thread[threadCount];

            for (int t = 0; t < threadCount; t++)
            {
                int start = t * rowsThread;
                int end = (t == threadCount - 1) ? rows : start + rowsThread;

                threads[t] = new Thread(() =>
                {
                    for (int i = start; i < end; i++)
                    {
                        for (int j = 0; j < m1[i].Length; j++)
                        {
                            result[i][j] = m1[i][j] + m2[i][j];
                        }
                    }
                });

                threads[t].Start();
            }

            for (int t = 0; t < threadCount; t++)
            {
                threads[t].Join();
            }
        }
    }
}
