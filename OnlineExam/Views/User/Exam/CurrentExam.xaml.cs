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
    /// Interaction logic for CurrentExam.xaml
    /// </summary>
    public partial class CurrentExam : Page
    {
        private CurrentExamViewModel _vm;
        public CurrentExam()
        {
            InitializeComponent();

            _vm = new CurrentExamViewModel();
            DataContext = _vm;
        }

        private void TakeExam_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var examTaken = btn.DataContext as Models.ExamTaken;

            if (examTaken == null) return;

            if (_vm.UpdateExam(examTaken)) {
                var window = Window.GetWindow(this) as UserPanel;
                window.SwitchPage(new TakeExam(examTaken));
            }
        }
    }
}
