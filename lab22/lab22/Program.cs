/*
    Введена строка символов. Необходимо разделить строку на слова. 
    Во всех полученных словах преобразовать
    последовательность символов в слове на обратную и сформировать результирующую строку с сохранением порядка слов.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();

            var reversedWords = string.Join(" ", //соеденяем полученные слова
              str.Split(' ')
                 .Select(x => new String(x.Reverse().ToArray()))); // перегружаем с помощью ToArray()

            Console.WriteLine(reversedWords);

            Console.WriteLine("Для выхода нажмите Enter");
            Console.ReadKey();
        }
    }
}


