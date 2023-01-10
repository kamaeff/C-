using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        bool f_open, f_save;
        int N = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            

            string line;
            int[] F_file = new int[N];
            using (var sw = new StreamReader("f.txt"))
            {
                line = sw.ReadLine();
                string[] str = line.Split(' ');

                for (int j = 0; j < F_file.Length; j++)
                {
                    F_file[j] = Convert.ToInt32(str[j]);
                }

                for (int h = 0; h < F_file.Length; h++)
                {
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
                        F_file[h].ToString();
                        
                        textBox2.AppendText(F_file[h] + " ");
                        

                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(sfd.FileName, textBox2.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                int[] arr = new int[N];
                Random r = new Random();
                using (var bw = new StreamWriter("f.txt"))
                {
                    while (i < N)
                    {
                        arr[i] = r.Next(0, 10);
                        Console.Write(arr[i] + " ");
                        bw.Write(arr[i] + " ");
                        i++;
                    }
                }

                // 3. Установить флажки f_open и f_save
                f_open = true;
                f_save = false;

                // 4. Прочитать файл в TextBox1
                // очистить предыдущий текст в richTextBox1
                textBox1.Clear();

                // 5. Создать объект класса StreamReader и прочитать данные из файла
                StreamReader sr = System.IO.File.OpenText(openFileDialog1.FileName);

                // дополнительная переменная для чтения строки из файла
                string line = null;
                line = sr.ReadLine(); // чтение первой строки

                // 6. Цикл чтения строк из файла, если строки уже нет, то line=null
                while (line != null)
                {
                    // 6.1. Добавить строку в TextBox1
                    textBox1.AppendText(line);

                    // 6.3. Считать следующую строку
                    line = sr.ReadLine();
                }

                // 7. Закрыть соединение с файлом
                sr.Close();
            }
        }
    }
}
