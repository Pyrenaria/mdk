using AppFokina.Classes;
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

namespace AppFokina.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        private Кулинария bludo = new Кулинария();
        public PageAddEdit()
        {
            InitializeComponent();

            CmbCat.ItemsSource =
                mdkEntities.GetContext().Категория.ToList();
            CmbCat.SelectedValuePath = "ID_Категории";
            CmbCat.DisplayMemberPath = "Название_категории";

            CmbEdin.ItemsSource =
                mdkEntities.GetContext().Измерение.ToList();
            CmbEdin.SelectedValuePath = "ID_Единиц";
            CmbEdin.DisplayMemberPath = "Единица_измерения";

            //создаем контекст

            DataContext = bludo;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (bludo.ID == 0)
                mdkEntities.GetContext().
                    Кулинария.Add(bludo); //добавить в контекст

            try
            {
                mdkEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
                ClassFrame.frmObj.Navigate(new PageComp());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
