using OnlineExam.ViewModels.Admin.Student;
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

namespace OnlineExam.Views.Admin.Student
{
    /// <summary>
    /// Interaction logic for ShowStudents.xaml
    /// </summary>
    public partial class ShowStudents : Page
    {
        private ShowStudentsViewModel _vm;
        public ShowStudents()
        {
            InitializeComponent();

            _vm = new ShowStudentsViewModel();
            DataContext = _vm;
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveStudent());
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var student = btn.DataContext as Models.Student;

            if (student == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to delete {student.FullName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.RemoveStudent(student);
        }

        private void EditStudent(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var student = btn.DataContext as Models.Student;

            if (student == null) return;

            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveStudent(student));
        }
    }
}
