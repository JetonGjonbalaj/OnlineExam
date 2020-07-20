using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Student;
using OnlineExam.Domain.Commands.Handler.Student;
using OnlineExam.Domain.Queries.Handler.Student;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Student
{
    public class ShowStudentsViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public BindingList<Models.Student> Students { get; set; }

        public ShowStudentsViewModel()
        {
            Errors = new BindingList<string>();
            Students = new BindingList<Models.Student>();

            GetStudents();
        }

        public void RemoveStudent(Models.Student student)
        {
            IsBusy = true;

            var command = new DeleteStudentCommand(student.UserId);
            var handler = new DeleteStudentCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                Students.Remove(student);
                if (Students.Count == 0)
                {
                    Errors.Add("No student found! Create one.");
                }
            }

            MessageBox.Show(result.Message);

            IsBusy = false;
        }

        private void GetStudents()
        {
            IsBusy = true;

            var hanlder = new AllStudentsQueryHandle();
            var professors = hanlder.Get();

            if (professors.Count() != 0)
            {
                foreach (var professor in professors)
                {
                    Students.Add(professor);
                }
            }
            else
            {
                Errors.Add("No student found! Create one.");
            }

            IsBusy = false;
        }
    }
}
