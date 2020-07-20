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
        private DatabaseContext _context;
        public User LoggedUser { get; private set; }
        public DatabaseContext Context
        {
            get { return _context; }
            set
            {
                if (value != null)
                {
                    _context = value;
                }
            }
        }
        public App()
        {
            //var query = new AllDepartmentsQueryHandler();
            //var departments = query.Get().ToList();

            //var departmentQuery = new OneDepartmentQuery(1);
            //var query2 = new OneDepartmentQueryHandler(departmentQuery);
            //var department = query2.Get();

            //var course = new Course() { CourseName = "Test", Department = department };
            //var command = new SaveCourseCommand(course);
            //var handler = new SaveCourseCommandHandler(command);
            //handler.Execute();

            //department.DepartmentName = "";

            //var courseQuery = new OneDepartmentQuery(500);
            //var query2 = new OneDepartmentQueryHandler(courseQuery);
            //var course = query2.Get();



            //var command = new SaveDepartmentCommand(department);
            //var handler = new SaveDepartmentCommandHandler(command);
            //var response = handler.Execute();

            //Console.WriteLine(response.Message);


            LoggedUser = null;
            Context = new DatabaseContext();
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
