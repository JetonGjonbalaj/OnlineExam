using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Exam;
using OnlineExam.Domain.Commands.Handler.Exam;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Services;
using OnlineExam.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.Admin.Exam
{
    public class ShowExamsViewModel : BaseViewModel
    {
        public BindingList<string> Errors { get; set; }
        public BindingList<Models.Exam> Exams { get; set; }

        public ShowExamsViewModel()
        {
            Errors = new BindingList<string>();
            Exams = new BindingList<Models.Exam>();

            GetExams();
        }

        public void RemoveExam(Models.Exam exam)
        {
            IsBusy = true;

            var command = new DeleteExamCommand(exam.ExamId);
            var handler = new DeleteExamCommandHandler(command);
            var result = handler.Execute();

            if (result.Success)
            {
                Exams.Remove(exam);
                if (Exams.Count == 0)
                {
                    Errors.Add("No exam found! Create one.");
                }
            }

            MessageBox.Show(result.Message);

            IsBusy = false;
        }

        private void GetExams()
        {
            IsBusy = true;

            var hanlder = new AllAvailableExamsQueryHandler();
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
                Errors.Add("No exam found! Create one.");
            }

            IsBusy = false;
        }
    }
}
