using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Math;

namespace AppFokina.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePR6.xaml
    /// </summary>
    public partial class PagePR6 : Page
    {
        public PagePR6()
        {
            InitializeComponent();
        }

        private void btnListFromFile_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader(@"Строки.txt", Encoding.UTF8);



            while (!sr.EndOfStream)
            {
                lstInput.Items.Add(sr.ReadLine());
            }

        }

        private void btnRezult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lstInput.SelectedIndex;
                string str = (string)lstInput.Items[index];
                int len = str.Length;
                int count = 0;
                int i = 0;




                while (i < len - 1)
                {
                    if (str[i] == ' ')
                        count++;
                    i++;
                }

                int col = Regex.Matches(str, @"[А-ЯЁа-яё]").Count;


                txbBuk.Text = "Количество букв: " + col.ToString();

                txbRezult.Text = "Количество пробелов: " + count.ToString();

                string line = lstInput.SelectedItem.ToString();


                StreamWriter sw = new StreamWriter(@"Rezult.txt");
                sw.WriteLine($"Номер строки: {index}");
                sw.WriteLine($"Исходная строка: {line}");
                sw.WriteLine($"новая строка: {txbRezult.Text}");
                sw.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            lstInput.Items.Clear();
            txbBuk.Text = "Количество букв: ";
            txbRezult.Text = "Количество пробелов: ";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR7());
        }

        private void Backk_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR3());
        }
    }
}
