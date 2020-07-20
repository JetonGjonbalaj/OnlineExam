using Microsoft.EntityFrameworkCore.Storage;
using OnlineExam.Context;
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
        private DatabaseContext _context;
        public BindingList<string> Errors { get; set; }
        public LoginViewModel()
        {
            _context = ((App)Application.Current).Context;

            Errors = new BindingList<string>();
        }

        public bool UserLoggedIn(string email, string password)
        {
            Errors.Clear();

            var app = (App)Application.Current;
            var professorService = new RepositoryService<Professor>(_context);
            var studentService = new RepositoryService<Student>(_context);

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


            var professor = professorService.Get(u => u.Email == email).FirstOrDefault();
            var student = studentService.Get(u => u.Email == email, "Department,ExamsTaken.Exam.Questions.Answers").FirstOrDefault();
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
