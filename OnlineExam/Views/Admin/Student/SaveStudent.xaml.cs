using OnlineExam.ViewModels.Admin.Student;
using Syncfusion.Windows.Shared;
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
    /// Interaction logic for SaveStudent.xaml
    /// </summary>
    public partial class SaveStudent : Page
    {
        private SaveStudentViewModel _vm;

        public SaveStudent()
        {
            InitializeComponent();

            _vm = new SaveStudentViewModel();
            DataContext = _vm;
        }

        public SaveStudent(Models.Student student)
        {
            InitializeComponent();

            _vm = new SaveStudentViewModel(student);
            DataContext = _vm;
        }

        private void SaveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!password.Password.IsNullOrWhiteSpace())
                _vm.Student.Password = password.Password;

            _vm.SaveStudent();
        }
    }
}
