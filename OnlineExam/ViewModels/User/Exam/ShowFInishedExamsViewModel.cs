using OnlineExam.Domain.Queries.Handler.ExamTaken;
using OnlineExam.Domain.Queries.Query.ExamTaken;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.ViewModels.User.Exam
{
    public class ShowFinishedExamsViewModel : BaseViewModel
    {
        public BindingList<Models.ExamTaken> ExamsTaken { get; set; }
        public BindingList<string> Errors { get; set; }

        public ShowFinishedExamsViewModel()
        {
            ExamsTaken = new BindingList<Models.ExamTaken>();
            Errors = new BindingList<string>();

            GetFinishedExams();
        }

        public void GetFinishedExams()
        {
            var student = ((App)Application.Current).LoggedUser as Models.Student;

            var query = new AllFinishedExamsQuery(student);
            var hanlder = new AllFinishedExamsQueryHandler(query);
            var examsTaken = hanlder.Get();

            if (examsTaken.Count() != 0)
            {
                foreach (var examTaken in examsTaken)
                {
                    ExamsTaken.Add(examTaken);
                }
            }
            else
            {
                Errors.Add("You didn't finish any exam!");
            }
        }
    }
}
