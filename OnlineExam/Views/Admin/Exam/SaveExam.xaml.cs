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
    /// Interaction logic for SaveExam.xaml
    /// </summary>
    public partial class SaveExam : Page
    {
        private SaveExamViewModel _vm;

        public SaveExam()
        {
            InitializeComponent();

            _vm = new SaveExamViewModel();
            DataContext = _vm;
        }

        public SaveExam(Models.Exam exam)
        {
            InitializeComponent();

            _vm = new SaveExamViewModel(exam);
            DataContext = _vm;
        }

        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            _vm.AddQuestion();
        }

        private void AddAnswer(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var question = btn.DataContext as Models.Question;

            if (question == null) return;

            _vm.AddAnswer(question);
        }

        private void RemoveQuestion(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var question = btn.DataContext as Models.Question;

            if (question == null) return;

            _vm.RemoveQuestion(question);
        }

        private void RemoveAnswer(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var answer = btn.DataContext as Models.Answer;
            var question = answer.Question;

            if (answer == null) return;

            _vm.RemoveAnswer(question, answer);
        }

        private void SfDatePicker_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue;
            DateTime date = Convert.ToDateTime(newValue);

            if (_vm == null || date == null) return;

            _vm.SetDate(date);
        }

        private void SfTimePicker_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue.ToString();
            DateTime date = Convert.ToDateTime(newValue);
            TimeSpan timespan = date.TimeOfDay;

            if (_vm == null || timespan == null) return;

            _vm.SetStartTime(timespan);
        }

        private void SfTimePicker_ValueChanged_1(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue.ToString();
            DateTime date = Convert.ToDateTime(newValue);
            TimeSpan timespan = date.TimeOfDay;

            if (_vm == null || timespan == null) return;

            _vm.SetEndTime(timespan);
        }
    }
}
