using OnlineExam.ViewModels.Admin.Professor;
using Syncfusion.Windows.Shared;
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

namespace OnlineExam.Views.Admin.Professor
{
    /// <summary>
    /// Interaction logic for SaveProfessor.xaml
    /// </summary>
    public partial class SaveProfessor : Page
    {
        private SaveProfessorViewModel _vm;

        public SaveProfessor()
        {
            InitializeComponent();

            _vm = new SaveProfessorViewModel();
            DataContext = _vm;
        }

        public SaveProfessor(Models.Professor professor)
        {
            InitializeComponent();

            _vm = new SaveProfessorViewModel(professor);
            DataContext = _vm;
        }

        private void SaveProfessor_Click(object sender, RoutedEventArgs e)
        {
            if (!password.Password.IsNullOrWhiteSpace())
                _vm.Professor.Password = password.Password;

            _vm.SaveProfessor();
        }
    }
}
