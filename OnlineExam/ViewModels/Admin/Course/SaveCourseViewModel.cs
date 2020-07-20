using OnlineExam.Domain.Commands.Command.Course;
using OnlineExam.Domain.Commands.Handler.Course;
using OnlineExam.Domain.Queries.Handler;
using OnlineExam.Domain.Queries.Handler.Course;
using OnlineExam.Domain.Queries.Query;
using OnlineExam.Domain.Queries.Query.Course;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlineExam.ViewModels.Admin.Course
{
    public class SaveCourseViewModel : BaseViewModel
    {
        public ICommand Command { get; set; }

        private Models.Course _course;
        public Models.Course Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }

        public BindingList<Models.Department> Departments { get; set; }

        public BindingList<string> Errors { get; set; }

        public SaveCourseViewModel()
        {
            _course = new Models.Course();

            Command = new Command(SaveCourse);
            Departments = new BindingList<Models.Department>();
            Errors = new BindingList<string>();

            GetDepartments();
        }

        public SaveCourseViewModel(Models.Course course)
        {
            Command = new Command(SaveCourse);
            Departments = new BindingList<Models.Department>();
            Errors = new BindingList<string>();
            

            var query = new OneCourseQuery(course.CourseId);
            var handler = new OneCourseQueryHandler(query);
            var result = handler.Get();

            if (result != null)
            {
                _course = new Models.Course()
                {
                    CourseId = result.CourseId,
                    CourseName = result.CourseName,
                    Department = result.Department,
                    Exams = new BindingList<Models.Exam>(result.Exams.ToList()),
                    Professors = new BindingList<Models.Professor>(result.Professors.ToList())
                };
                result = null;
            }
            else
            {
                Errors.Add("There is no course!");
            }

            GetDepartments();
        }

        private void SaveCourse()
        {
            IsBusy = true;
            Errors.Clear();

            var command = new SaveCourseCommand(_course);
            var handler = new SaveCourseCommandHandler(command);
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
    }
}
