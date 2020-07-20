using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Course;
using OnlineExam.Domain.Commands.Handler.Course;
using OnlineExam.Domain.Queries.Handler.Course;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Course
{
    public class ShowCoursesViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public BindingList<Models.Course> Courses { get; set; }

        public ShowCoursesViewModel()
        {
            Errors = new BindingList<string>();
            Courses = new BindingList<Models.Course>();

            GetCourses();
        }

        public void RemoveCourse(Models.Course course)
        {
            IsBusy = true;

            var command = new DeleteCourseCommand(course.CourseId);
            var handler = new DeleteCourseCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                Courses.Remove(course);
                if (Courses.Count == 0)
                {
                    Errors.Add("No department found! Create one.");
                }
            }

            MessageBox.Show(result.Message);

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
