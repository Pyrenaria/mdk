using AppFokina.Pages;
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

namespace AppFokina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.ClassFrame.frmObj = FrmMain;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string login = Log.Text;
            string password = Pas.Password;

            if (login == "Лизонька")
            {
                if (password == "4862")
                {

                    Classes.ClassFrame.frmObj.Navigate(new PagePR1());
                }
                else
                {
                    MessageBox.Show("Неверный пароль ♥");
                }
            }
            else
            {
                MessageBox.Show("Во входе отказано ♥");
            }

        }
    }
}
