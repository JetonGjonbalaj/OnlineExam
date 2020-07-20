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
    /// Interaction logic for TakeExam.xaml
    /// </summary>
    public partial class TakeExam : Page
    {
        private TakeExamViewModel _vm;
        public TakeExam(Models.ExamTaken examTaken)
        {
            InitializeComponent();

            _vm = new TakeExamViewModel(examTaken);
            DataContext = _vm;
        }
    }
}
