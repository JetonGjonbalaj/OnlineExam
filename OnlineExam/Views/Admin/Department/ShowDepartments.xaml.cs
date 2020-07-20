using OnlineExam.ViewModels.Admin.Department;
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

namespace OnlineExam.Views.Admin.Department
{
    /// <summary>
    /// Interaction logic for ShowDepartment.xaml
    /// </summary>
    public partial class ShowDepartments : Page
    {
        private ShowDepartmentsViewModel _vm;
        public ShowDepartments()
        {
            InitializeComponent();

            _vm = new ShowDepartmentsViewModel();
            DataContext = _vm;
        }

        private void DeleteDepartment(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dep = btn.DataContext as Models.Department;

            if (dep == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to delete {dep.DepartmentName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.RemoveDepartment(dep);
        }

        private void EditDepartment(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dep = btn.DataContext as Models.Department;

            if (dep == null) return;

            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveDepartment(dep));
        }

        private void AddDepartment(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveDepartment());
        }
    }
}
