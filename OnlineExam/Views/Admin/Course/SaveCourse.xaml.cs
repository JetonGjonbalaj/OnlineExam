using OnlineExam.ViewModels.Admin.Course;
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

namespace OnlineExam.Views.Admin.Course
{
    /// <summary>
    /// Interaction logic for SaveCourse.xaml
    /// </summary>
    public partial class SaveCourse : Page
    {
        private SaveCourseViewModel _vm;

        public SaveCourse()
        {
            InitializeComponent();

            _vm = new SaveCourseViewModel();
            DataContext = _vm;
        }

        public SaveCourse(Models.Course course)
        {
            InitializeComponent();

            _vm = new SaveCourseViewModel(course);
            DataContext = _vm;
        }
    }
}
