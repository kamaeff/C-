using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding= Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write($"Введите колличество строк в масстве(Столбцов будет такое же колличество: ");

            Random r = new Random();
            int N = Int32.Parse(Console.ReadLine());
            int M = N;
            int[,] arr = new int[N,M];

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) {
                    arr[i, j] = r.Next(0, 20);
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (i>N-1-j || i==j || i == N-1-j || i>j)
                    {
                        sum += arr[i,j];
                    }
                }
            }

            Console.WriteLine("Ответ:" + sum);
            Console.WriteLine($"Для закрытия нажмите Enter");
            Console.ReadLine();
        }
    }
}
