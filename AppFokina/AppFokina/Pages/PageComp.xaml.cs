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
    /// Логика взаимодействия для PageComp.xaml
    /// </summary>
    public partial class PageComp : Page
    {
        public PageComp()
        {
            InitializeComponent();

            DtgListStudent.ItemsSource =
               mdkEntities.GetContext().Кулинария.ToList();

            CmbDiscipline.ItemsSource = mdkEntities.GetContext().
                 Категория.ToList();
            CmbDiscipline.SelectedValuePath = "ID_Категории";
            CmbDiscipline.DisplayMemberPath = "Название_категории";

        }


        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            LstResults.Items.Clear();
            //подсчет агрегатных функций

            int count = mdkEntities.GetContext().
                Кулинария.Count();

            double averageMark = (double)mdkEntities.GetContext().
                Кулинария.Select(x => x.Цена).Average();

            double minMark = (double)mdkEntities.GetContext().
                Кулинария.Select(x => x.Цена).Min();

            double maxMark = (double)mdkEntities.GetContext().
                Кулинария.Select(x => x.Цена).Max();

            double sumMark = (double)mdkEntities.GetContext().
                Кулинария.Select(x => x.Цена).Sum();

            LstResults.Items.Add($"Количество записей {count}");
            LstResults.Items.Add($"Средняя цена {averageMark}");
            LstResults.Items.Add($"Минимальная цена {minMark}");
            LstResults.Items.Add($"Максимальная цена {maxMark}");
            LstResults.Items.Add($"Общая сумма цен {sumMark}");

            string minMarkFIO = mdkEntities.GetContext().
                Кулинария.First(x => x.Цена == minMark).Название_Блюда.ToString();
            MessageBox.Show(minMarkFIO);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddEdit());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление нескольких строк
            var studentsForRemoving = DtgListStudent.SelectedItems.Cast<Кулинария>().ToList();

            if (MessageBox.Show
                ($"Удалить {studentsForRemoving.Count()} " +
                $"блюдо?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    mdkEntities.GetContext().
                        Кулинария.RemoveRange(studentsForRemoving);

                    mdkEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgListStudent.ItemsSource =
                        mdkEntities.GetContext().
                        Кулинария.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }
        private void Backk_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePR7());
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idDisc = int.Parse(CmbDiscipline.SelectedValue.ToString());
            DtgListStudent.ItemsSource =
                mdkEntities.GetContext().Кулинария.
                Where(x => x.ID_Категории == idDisc).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgListStudent.ItemsSource =
                mdkEntities.GetContext().Кулинария.
                Where(x => x.Название_Блюда.Contains(search)).ToList();
        }

        private void RbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по возрастанию
            DtgListStudent.ItemsSource =
                mdkEntities.GetContext().Кулинария.
                OrderBy(x => x.Цена).ToList();
        }

        private void RbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по убыванию
            DtgListStudent.ItemsSource =
                mdkEntities.GetContext().Кулинария.
                OrderByDescending(x => x.Цена).ToList();
        }
    }
}
