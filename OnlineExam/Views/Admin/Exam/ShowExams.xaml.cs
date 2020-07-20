using OnlineExam.ViewModels.Admin.Exam;
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

namespace OnlineExam.Views.Admin.Exam
{
    /// <summary>
    /// Interaction logic for ShowExams.xaml
    /// </summary>
    public partial class ShowExams : Page
    {
        private ShowExamsViewModel _vm;
        public ShowExams()
        {
            InitializeComponent();

            _vm = new ShowExamsViewModel();
            DataContext = _vm;
        }

        private void AddExam(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveExam());
        }

        private void DeleteExam(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var exam = btn.DataContext as Models.Exam;

            if (exam == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to delete {exam.ExamName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.RemoveExam(exam);
        }

        private void EditExam(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var exam = btn.DataContext as Models.Exam;

            if (exam == null) return;

            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveExam(exam));
        }
    }
}
