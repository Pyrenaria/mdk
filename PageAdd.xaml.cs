using SchoolAssistant.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace SchoolAssistant.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        grades _currentGrade = new grades();

        public int sId = (int)App.Current.Resources["sbjId"];

        private void CmbCls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string clas = (string)(CmbCls.SelectedValue);

            CmbFcs.ItemsSource = gradesEntities.GetContext().pupils.Where(x => x.classID == clas).ToList();
            CmbFcs.SelectedValuePath = "pupilID";
            CmbFcs.DisplayMemberPath = "fcs";
        }
        public PageAdd(grades gradelocal)
        {
            InitializeComponent();

            CmbCls.ItemsSource = gradesEntities.GetContext().classes.Select(x => x.classID).Distinct().ToList();


            CmbSbj.ItemsSource = gradesEntities.GetContext().subjects.Where(x => x.subjectID == sId).ToList();
            CmbSbj.SelectedValuePath = "subjectID";
            CmbSbj.DisplayMemberPath = "name";

            if (gradelocal != null) _currentGrade = gradelocal;
            DataContext = _currentGrade;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGrade.gradeID == 0)

                gradesEntities.GetContext().grades.Add(_currentGrade);

            gradesEntities.GetContext().SaveChanges();

            MessageBoxResult boxResult = MessageBox.Show("Данные добавлены. Добавить еще?", "Сообщение", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                TxtGrd.Clear();
                TxtDate.Clear();
            }
            else
                Classes.ClassFrame.frmObj.Navigate(new Pages.SchoolClass(sId));

        }
    }
}