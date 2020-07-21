using Microsoft.EntityFrameworkCore.Storage;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Handler.Professor;
using OnlineExam.Domain.Queries.Handler.Student;
using OnlineExam.Domain.Queries.Query.Professor;
using OnlineExam.Domain.Queries.Query.Student;
using OnlineExam.Models;
using OnlineExam.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public LoginViewModel()
        {
            Errors = new BindingList<string>();
        }

        public bool UserLoggedIn(string email, string password)
        {
            Errors.Clear();

            var app = (App)Application.Current;

            if (string.IsNullOrWhiteSpace(email))
            {
                Errors.Add("Email is empty!");
                return app.UserIsLogged();
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                Errors.Add("Password is empty!");
                return app.UserIsLogged();
            }

            var professorQuery = new LoginProfessorQuery(email);
            var professorHandler = new LoginProfessorQueryHandler(professorQuery);
            var professor = professorHandler.Get();

            var studentQuery = new LoginStudentQuery(email);
            var studentHandler = new LoginStudentQueryHandler(studentQuery);
            var student = studentHandler.Get();

            Models.User user = null;

            if (professor != null && professor.Password == password)
            {
                user = professor;
            }
            else if (student != null && student.Password == password) {
                user = student;
            }
            else
            {
                Errors.Add("Please check your credentials!");
            }

            app.LoginUser(user);
            return app.UserIsLogged();
        }
    }
}
