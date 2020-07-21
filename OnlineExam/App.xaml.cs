using FluentValidation.Results;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Course;
using OnlineExam.Domain.Commands.Command.Department;
using OnlineExam.Domain.Commands.Handler.Course;
using OnlineExam.Domain.Commands.Handler.Department;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Handler.Course;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query;
using OnlineExam.Domain.Queries.Query.Course;
using OnlineExam.Models;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public User LoggedUser { get; private set; }

        public App()
        {
            LoggedUser = null;
        }

        public bool UserIsLogged()
        {
            return LoggedUser != null;
        }

        public void LoginUser(User user)
        {
            if (user != null)
                LoggedUser = user;
        }

        public void LogoutUser()
        {
            LoggedUser = null;
        }

        public int UserRole()
        {
            if (UserIsLogged())
            {
                return (int)LoggedUser.Role;
            }
            return -1;
        }
    }
}
