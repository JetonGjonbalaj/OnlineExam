using OnlineExam.ViewModels.Admin.Professor;
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
    /// Interaction logic for ShowProfessors.xaml
    /// </summary>
    public partial class ShowProfessors : Page
    {
        private ShowProfessorsViewModel _vm;
        public ShowProfessors()
        {
            InitializeComponent();

            _vm = new ShowProfessorsViewModel();
            DataContext = _vm;
        }

        private void AddProfessor(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveProfessor());
        }

        private void DeleteProfessor(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var professor = btn.DataContext as Models.Professor;

            if (professor == null) return;

            MessageBoxResult msgBox = MessageBox.Show($"Do you want to delete {professor.FullName}?", "Delete", MessageBoxButton.YesNo);

            if (msgBox == MessageBoxResult.Yes)
                _vm.RemoveProfessor(professor);
        }

        private void EditProfessor(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var professor = btn.DataContext as Models.Professor;

            if (professor == null) return;

            var window = Window.GetWindow(this) as AdminPanel;
            window.SwitchPage(new SaveProfessor(professor));
        }
    }
}
