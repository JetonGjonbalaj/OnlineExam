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
    /// Interaction logic for ShowFinishedExams.xaml
    /// </summary>
    public partial class ShowFinishedExams : Page
    {
        private ShowFinishedExamsViewModel _vm;
        public ShowFinishedExams()
        {
            InitializeComponent();

            _vm = new ShowFinishedExamsViewModel();
            DataContext = _vm;
        }
    }
}
