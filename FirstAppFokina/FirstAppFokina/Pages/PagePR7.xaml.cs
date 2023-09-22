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
    /// Логика взаимодействия для PagePR7.xaml
    /// </summary>
    public partial class PagePR7 : Page
    {
        public PagePR7()
        {
            InitializeComponent();
        }

        private void Backk_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR3());

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

            lstY.Items.Clear();
            lstR.Items.Clear();
            int size = 25;
            int[] y = new int[size];
            Random rand = new Random();
            double [] r = new double [25];
            int i, j = 0;

            for (i = 0; i < size; i++)
            {
                y[i] = rand.Next(0, 60);
               lstY.Items.Add(y[i].ToString());

                
            }


            for (j = 0; j < size; j++) 
            
            {
                r[j] = (5 * y[j] + Pow(Cos(y[j]), 2)) / 2.35;

                Math.Round(r[j], 2);
                
                lstR.Items.Add(r[j].ToString());
            }

           




            //lstR.Items.Add($"{r[j]}");
            
            



        }
    }
}
