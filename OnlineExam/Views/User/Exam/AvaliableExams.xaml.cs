using OnlineExam.ViewModels.User.Exam;
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

namespace OnlineExam.Views.User.Exam
{
    /// <summary>
    /// Interaction logic for AvaliableExams.xaml
    /// </summary>
    public partial class AvaliableExams : Page
    {
        private AvailableExamsViewModel _vm;
        public AvaliableExams()
        {
            InitializeComponent();

            _vm = new AvailableExamsViewModel();
            DataContext = _vm;
        }

        private void TakeExam_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var exam = btn.DataContext as Models.Exam;

            if (exam == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to take {exam.ExamName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.AddExam(exam);
        }
    }
}
