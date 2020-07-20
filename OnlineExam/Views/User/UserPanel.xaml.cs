using OnlineExam.Views.User.Exam;
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

namespace OnlineExam.Views.User
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();

            FrameElem.Content = new AvaliableExams();
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
    }
}
