using OnlineExam.Views.Admin.Course;
using OnlineExam.Views.Admin.Department;
using OnlineExam.Views.Admin.Exam;
using OnlineExam.Views.Admin.Professor;
using OnlineExam.Views.Admin.Student;
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
using System.Windows.Shapes;

namespace OnlineExam.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();

            FrameElem.Content = new WelcomePage();
        }

        public void SwitchPage(Page page)
        {
            FrameElem.Content = page;
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            Type page = btn.Tag as Type;
            var newPage = Activator.CreateInstance(page) as Page;

            SwitchPage(newPage);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            var loginWindow = new LoginWindow();

            app.LogoutUser();

            if (!app.UserIsLogged())
            {
                loginWindow.Show();
                this.Close();
            }
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            var professor = ((App)Application.Current).LoggedUser as Models.Professor;
            var editPage = new SaveProfessor(professor);

            SwitchPage(editPage);
        }
    }
}
