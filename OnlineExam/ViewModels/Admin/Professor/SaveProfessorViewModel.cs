using OnlineExam.Domain.Commands.Command.Professor;
using OnlineExam.Domain.Commands.Handler.Professor;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Handler.Course;
using OnlineExam.Domain.Queries.Handler.Professor;
using OnlineExam.Domain.Queries.Query.Professor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Professor
{
    public class SaveProfessorViewModel : BaseViewModel
    {
        private Models.Professor _professor;
        public Models.Professor Professor
        {
            get { return _professor; }
            set { SetProperty(ref _professor, value); }
        }

        public BindingList<Models.Department> Departments { get; set; }
        public BindingList<Models.Course> Courses { get; set; }
        public BindingList<string> Errors { get; set; }

        public SaveProfessorViewModel()
        {
            _professor = new Models.Professor();

            Departments = new BindingList<Models.Department>();
            Courses = new BindingList<Models.Course>();
            Errors = new BindingList<string>();

            GetDepartments();
            GetCourses();
        }

        public SaveProfessorViewModel(Models.Professor professor)
        {
            Departments = new BindingList<Models.Department>();
            Courses = new BindingList<Models.Course>();
            Errors = new BindingList<string>();

            var query = new OneProfessorQuery(professor.UserId);
            var handler = new OneProfessorQueryHandler(query);
            var result = handler.Get();

            if (result != null)
            {
                _professor = new Models.Professor()
                {
                    UserId = result.UserId,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    Password = result.Password,
                    ProfessorId = result.ProfessorId,
                    Role = result.Role,
                    Course = result.Course,
                    Department = result.Department,
                };

                result = null;
            }
            else
            {
                Errors.Add("There is no professor!");
            }

            GetDepartments();
            GetCourses();
        }

        public void SaveProfessor()
        {
            IsBusy = true;
            Errors.Clear();

            var command = new SaveProfessorCommand(_professor);
            var handler = new SaveProfessorCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Errors.Add(result.Message);
            }

            IsBusy = false;
        }

        private void GetDepartments()
        {
            IsBusy = true;

            var hanlder = new AllDepartmentsQueryHandler();
            var departments = hanlder.Get();

            if (departments.Count() != 0)
            {
                foreach (var department in departments)
                {
                    Departments.Add(department);
                }
            }
            else
            {
                Errors.Add("No department found! Create one.");
            }

            IsBusy = false;
        }

        private void GetCourses()
        {
            IsBusy = true;

            var hanlder = new AllCoursesQueryHandler();
            var courses = hanlder.Get();

            if (courses.Count() != 0)
            {
                foreach (var course in courses)
                {
                    Courses.Add(course);
                }
            }
            else
            {
                Errors.Add("No course found! Create one.");
            }

            IsBusy = false;
        }
    }
}
