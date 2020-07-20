using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineExam.Context;
using OnlineExam.Enums;
using OnlineExam.Models;
using OnlineExam.Services;
using OnlineExam.ViewModels;
using OnlineExam.Views.Admin;
using OnlineExam.Views.User;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
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

namespace OnlineExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _vm;
        public LoginWindow()
        {
            InitializeComponent();

            _vm = new LoginViewModel();
            DataContext = _vm;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
            {
                var email = Email.Text;
                var password = Password.Password;

                if (_vm.UserLoggedIn(email, password))
                {
                    var app = (App)Application.Current;
                    var role = app.UserRole();
                    Window window = null;

                    if (role == (int)Role.Admin || role == (int)Role.Professor)
                    {
                        window = new AdminPanel();
                    } 
                    else
                    {
                        window = new UserPanel();
                    }

                    window.Show();

                    this.Close();
                }
            }
        }
    }
}
