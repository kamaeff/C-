/*
 * Lab3
 * Дан файл f, компоненты которого являются целыми числами.
 * Сформировать файл g, таким образом чтобы он содержал числа, которые не повторяются.
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random r = new Random();

            Console.Write("Я могу заполнить файл f случайными числами\nСколько чисел вы хотите? N=");
            int N = Int32.Parse(Console.ReadLine());

            int[] arr= new int[N];
            int i = 0;
          
            using (var bw = new StreamWriter("f.txt")) { 
                while (i < N)
                {
                    arr[i] = r.Next(0, 10);
                    Console.Write(arr[i] + " ");
                    bw.Write(arr[i] + " ");
                    i++;     
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Проверка на повторяющие числа...");

            string line;
            int[] F_file = new int[N];
            StreamWriter ds = new StreamWriter("g.txt");

            using (var sw = new StreamReader("f.txt"))
            {
                line = sw.ReadLine();

                string[] str = line.Split(' ');

                for (int j = 0; j < F_file.Length; j++)
                {
                    F_file[j] = Convert.ToInt32(str[j]);
                }

                for (int h = 0; h < F_file.Length; h++) {
                    int flag = 0;
                    for (int f = 0; f < N; f++)
                    {
                        if (F_file[h] == F_file[f])
                        {
                            flag++;
                        }
                    }
                    if (flag < 2)
                    {               
                        Console.Write(F_file[h] + " ");
                        ds.Write(F_file[h] + " "); 
                    }
                }
            }
            ds.Close();
            

            Console.WriteLine();
            Console.WriteLine($"Для закрытия нажмите Enter");
            Console.ReadLine();
        }
    }
}
