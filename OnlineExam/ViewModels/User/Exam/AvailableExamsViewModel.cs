using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.ExamTaken;
using OnlineExam.Domain.Commands.Handler.Exam;
using OnlineExam.Domain.Commands.Handler.ExamTaken;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query.Exam;
using OnlineExam.Enums;
using OnlineExam.Models;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.User.Exam
{
    public class AvailableExamsViewModel : BaseViewModel
    {
        public BindingList<Models.Exam> Exams { get; set; }
        public BindingList<string> Errors { get; set; }

        public AvailableExamsViewModel()
        {
            Exams = new BindingList<Models.Exam>();
            Errors = new BindingList<string>();

            GetAvailableExams();
        }

        public void GetAvailableExams()
        {
            IsBusy = true;

            var student = ((App)Application.Current).LoggedUser as Models.Student;

            var query = new AllStudentUpcomingExamsQuery(student.UserId);
            var hanlder = new AllStudentUpcomingExamsQueryHanlder(query);
            var exams = hanlder.Get();

            if (exams.Count() != 0)
            {
                foreach (var exam in exams)
                {
                    Exams.Add(exam);
                }
            }
            else
            {
                Errors.Add("No upcoming exam!");
            }

            IsBusy = false;
        }

        public void AddExam(Models.Exam exam)
        {
            Errors.Clear();

            IsBusy = true;

            var student = ((App)Application.Current).LoggedUser as Models.Student;

            if (exam == null)
            {
                Errors.Add("Exam was null!");
                return;
            }

            var examTaken = new ExamTaken() { Exam = exam, Student = student, Status = ExamStatus.Taken };
            var command = new SaveExamTakenCommand(examTaken);
            var handler = new SaveExamTakenCommandHandler(command);
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
    }
}
