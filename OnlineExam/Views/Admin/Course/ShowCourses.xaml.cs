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
    /// Interaction logic for ShowCourse.xaml
    /// </summary>
    public partial class ShowCourses : Page
    {
        private ShowCoursesViewModel _vm;
        public ShowCourses()
        {
            InitializeComponent();

            _vm = new ShowCoursesViewModel();
            DataContext = _vm;
        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveCourse());
        }

        private void DeleteCourse(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var course = btn.DataContext as Models.Course;

            if (course == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to delete {course.CourseName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.RemoveCourse(course);
        }

        private void EditCourse(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var course = btn.DataContext as Models.Course;

            if (course == null) return;

            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveCourse(course));
        }
    }
}
