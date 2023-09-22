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

namespace FirstAppFokina.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePR3.xaml
    /// </summary>
    public partial class PagePR3 : Page
    {
        public PagePR3()
        {
            InitializeComponent();
        }

        private void Backk_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR2());
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            lstResult.Items.Clear();

            double x0 = double.Parse(X0.Text);
            double xk = double.Parse(Xk.Text);
            double dx = double.Parse(Dx.Text); 
            double a = double.Parse(A.Text);
            
           

           
            lstResult.Items.Add("Лаб.раб.№2. Выполнила Ст.гр.ИСП212 Фокина Е.И. Вариант 7");
           

            while (x0 <= xk) 
            {
               double y   = 9 * (x0 + 15 * Sqrt(Pow(x0, 3) + Pow(a, 3)));
              
                lstResult.Items.Add($"X={x0}");
                lstResult.Items.Add($"Y={y}");
                x0 += dx;
            }



        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            X0.Clear();
            Xk.Clear();
            Dx.Clear();
            A.Clear();
            lstResult.Items.Clear();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR7());
        }
    }
}
