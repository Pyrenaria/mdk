using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для PagePR2.xaml
    /// </summary>
    public partial class PagePR2 : Page
    {
        public PagePR2()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            lstResult.Items.Clear();
            double x = double.Parse(txtX.Text);
            double y = double.Parse(txtY.Text);

            double u;
            lstResult.Items.Add("ИСП212 Фокина Е.");
            lstResult.Items.Add("Вариант 7");
            lstResult.Items.Add($"X={x}");
            lstResult.Items.Add($"Y={y}");

            int n = 0;
            if (rbtSqr.IsChecked == true) n = 1;
            else if (rbtExp.IsChecked == true) n = 2;
            switch (n)
            {
                case 0:
                    if (1 < x * y && x * y < 10) u = Exp(Sinh(x));
                    if (12 < x * y && x * y < 40) u = Sqrt(Abs(Sinh(x) + 4 * y));
                    else u = y * Sinh(x) * Sinh(x);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                case 1:
                    if (1 < x * y && x * y < 10) u = Exp(Pow(x, 2));
                    if (12 < x * y && x * y < 40) u = Sqrt(Abs(Pow(x, 2) + 4 * y));
                    else u = y * Pow(x, 2) * Pow(x, 2);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                case 2:
                    if (1 < x * y && x * y < 10) u = Exp(Exp(x));
                    if (12 < x * y && x * y < 40) u = Sqrt(Abs(Exp(x) + 4 * y));
                    else u = y * Exp(x) * Exp(x);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                default:
                    lstResult.Items.Add("Решение не найдено");
                    break;



            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            lstResult.Items.Clear();
        }

        private void Backk_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR1());
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR3());
        }
    }
}
