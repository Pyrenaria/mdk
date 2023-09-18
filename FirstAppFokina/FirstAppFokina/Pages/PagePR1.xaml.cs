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
    /// Логика взаимодействия для PagePR1.xaml
    /// </summary>
    public partial class PagePR1 : Page
    {
        public PagePR1()
        {
            InitializeComponent();
        }

        private void Perfom_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(meanX.Text);
            double y = Convert.ToDouble(meanY.Text);
            double z = Convert.ToDouble(meanZ.Text);

            double B = 5 * Math.Atan(x) - 0.25 * Math.Acos(x) * (x + 3 * Math.Abs(x - y) + (x * x)) / (Math.Abs(x - y) * z + (x * x));
            B = Round(B, 3);

            LstResult.Items.Add("Пр№1 ИСП.212 Фокина");
            LstResult.Items.Add($"x={x}");
            LstResult.Items.Add($"y={y}");
            LstResult.Items.Add($"z={z}");
            LstResult.Items.Add($"Результат B={B}");
        }

        private void next1_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PracWork10());
        }

        private void clear1_Click(object sender, RoutedEventArgs e)
        {
            LstResult.Items.Clear();
            meanX.Clear();
            meanY.Clear();
            meanZ.Clear();
        }
    }
}
