using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.ExamTaken;
using OnlineExam.Domain.Commands.Handler.ExamTaken;
using OnlineExam.Domain.Queries.Handler.ExamTaken;
using OnlineExam.Domain.Queries.Query.ExamTaken;
using OnlineExam.Enums;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.User.Exam
{
    public class CurrentExamViewModel : BaseViewModel
    {
        private DatabaseContext _context;
        public BindingList<Models.ExamTaken> Exams { get; set; }
        public BindingList<string> Errors { get; set; }

        public CurrentExamViewModel()
        {
            _context = ((App)Application.Current).Context;

            Exams = new BindingList<Models.ExamTaken>();
            Errors = new BindingList<string>();

            GetCurrentExams();
        }

        public void GetCurrentExams()
        {
            IsBusy = true;

            var student = ((App)Application.Current).LoggedUser as Models.Student;
            var query = new AllActiveExamTakenQuery(student);
            var hanlder = new AllActiveExamTakenQueryHandler(query);
            var examsTaken = hanlder.Get();

            if (examsTaken.Count() != 0)
            {
                foreach (var examTaken in examsTaken)
                {
                    Exams.Add(examTaken);
                }
            }
            else
            {
                Errors.Add("No exam found!");
            }

            IsBusy = false;
        }

        public bool UpdateExam(Models.ExamTaken examTaken)
        {
            examTaken.Status = ExamStatus.Pending;

            var command = new SaveExamTakenCommand(examTaken);
            var handler = new SaveExamTakenCommandHandler(command);
            var result = handler.Execute();

            return result.Success;
        }
    }
}
