/*
    Разработать класс Student: Фамилия, Имя, Отчество, Дата рождения, Адрес, Телефон, Факультет, Курс.
    Включить в класс методы set (…), get (…), show (…). Определить другие необходимые методы.
    Создать массив объектов (сразу уже подготовленный, без ввода). Вывести:
    а) список студентов заданного факультета;
    б) списки студентов для каждого факультета и курса;
    в) список студентов, родившихся после заданного года.
    Для вех выше пунктов данные вводятся с клавиатуры
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Student {
        private int id;
        private string sur;
        private string name;
        private string otch;
        private  int age;
        private string adress;
        private int number;
        private string facultet;
        private int curse;

        public int ID {
            get { return id; }
        }
        public string SUR {
            get { return sur; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Otch
        {
            get { return otch; }
        }
        public int Age
        {
            get { return age; }
        }
        public string Adress
        {
            get { return adress; }
        }
        public int Number
        {
            get { return number; }
        }
        public string Facultet
        {
            get { return facultet; }
        }
        public int Curse
        {
            get { return curse; }
        }

        public Student(int id, string sur, string name, string otch, int age, string adress, int number, string facultet, int curse)
        {
            this.id = id;
            this.sur = sur;
            this.name = name;
            this.otch = otch;
            this.age = age;
            this.adress = adress;
            this.number = number;
            this.facultet = facultet;
            this.curse = curse;
        }

    }

    class Programm {
        static Student[] GetStudent() {
            Student[] students = new Student[5];

            students[0] = new Student(1, "Камаев", "Антон", "Львович", 2001, "Йошкар-Ола", 89123820, "ФМФ", 3);
            students[1] = new Student(2, "Иванов", "Иван", "Иванович", 1999, "Москва", 8926378, "ИФ", 4);
            students[2] = new Student(3, "Васильев", "Василий", "Васильевич", 1998, "Мурманск", 89323238, "ФФК", 2);
            students[3] = new Student(4, "Соколов", "Василий", "Андреевич", 2000, "Уфа", 893231238, "ФМФ", 2);
            students[4] = new Student(5, "Долгоруков", "Василий", "Александрович", 2003, "Владивосток", 34893849, "ИФ", 1);

            return students;
        }

        static void Print(Student[] students, int count) {
            Console.WriteLine();
            Console.WriteLine($"ID: {students[count].ID}");
            Console.WriteLine($"Фамилия: {students[count].SUR}");
            Console.WriteLine($"Имя: {students[count].Name}");
            Console.WriteLine($"Отчество: {students[count].Otch}");
            Console.WriteLine($"Дата рождения: {students[count].Age}");
            Console.WriteLine($"Адрес: {students[count].Adress}");
            Console.WriteLine($"Номер телефона: {students[count].Number}");
            Console.WriteLine($"Факультет: {students[count].Facultet}");
            Console.WriteLine($"Курс: {students[count].Curse}");
        }

        static void Sort(Student[] students, string str) {
            for (int i = 0; i < 5; i++) {
                if (students[i].Facultet == str)
                {
                    Print(students, i);
                }     
            }
        }

        static void Sort2(Student[] students, string f, int c) {
            for (int i = 0; i < 5; i++) {
                if (students[i].Facultet == f || students[i].Curse == c)
                {
                    Print(students, i);
                }
            }
        }

        static void Sort3(Student[] students, int d) {
            for (int i = 0; i < 5; i++) {
                if (students[i].Age > d)
                {
                    Print(students, i);
                }
                
            }  
        }

        static int protectorINT() {
            int d;
            while (!int.TryParse(Console.ReadLine(), out d))
            {
                Console.WriteLine("Введите корректное число!");
                Console.Write("INPUT: ");
            }
            return d;
        }

        static int protectorSTRING(string str1)
        {
            string t = "ФФК";
            string g = "ФМФ";
            string h = "ИФ";

            int resault = string.Compare(str1, t);
            int resault2 = string.Compare(str1, g);
            int resault3 = string.Compare(str1, h);

            int FinalRes= 0;
            if (resault == 0 || resault2 == 0 || resault3 == 0) {
                FinalRes = 0;
            }

            return FinalRes;

        }

        static void Main(string[] args) {
            Console.WriteLine("------------------------Menu------------------------");
            Console.WriteLine("1.Cписок студентов заданного факультета");
            Console.WriteLine("2.Cписки студентов для каждого факультета и курса");
            Console.WriteLine("3.Cписок студентов, родившихся после заданного года");
            Console.WriteLine("------------------------Menu------------------------");
            Console.Write("INPUT: ");

            var students = GetStudent();
            int N = protectorINT();
            int resault;

            if (N < 0 || N > 3) {
                Console.WriteLine("Вы ввели неверный пункт!");
            }
            else{
                switch (N)
                {
                    case 1:
                        {
                            Console.Write("Список какого факультета вы хотите получить?: ");
                            string str1 = Console.ReadLine();
                            resault = protectorSTRING(str1);

                            if (resault == 0)
                            {
                                Sort(students, str1);
                            }
                            else
                            {
                                Console.WriteLine("Такого факультета не существует!");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Укажите факультет и курс.");

                            Console.Write("Факультет: ");
                            string f = Console.ReadLine();
                            resault = protectorSTRING(f);

                            Console.Write("Курс: ");
                            int c = protectorINT();

                            if (resault == 0 || c == 3 || c == 2 || c==1 || c==4)
                            {
                                Sort2(students, f, c);
                            }
                            else
                            {
                                Console.WriteLine("Такого факультета или курса не существует!");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Укажите год рождения: ");
                            int d =protectorINT();

                            if (d > 0 && d < 2147483648)
                            {
                                Sort3(students, d);
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели не корректное число!");
                            }
                            break;
                        }
                }

            }
                Console.WriteLine($"Для закрытия нажмите Enter");
                Console.ReadLine();
            }
    }
}

