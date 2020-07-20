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
    /// Interaction logic for SaveDepartment.xaml
    /// </summary>
    public partial class SaveDepartment : Page
    {
        private SaveDepartmentViewModel vm;

        public SaveDepartment()
        {
            InitializeComponent();

            vm = new SaveDepartmentViewModel();
            DataContext = vm;
        }

        public SaveDepartment(Models.Department department)
        {
            InitializeComponent();

            vm = new SaveDepartmentViewModel(department);
            DataContext = vm;
        }
    }
}
