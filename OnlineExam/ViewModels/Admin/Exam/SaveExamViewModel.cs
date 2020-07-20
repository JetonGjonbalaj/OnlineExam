using OnlineExam.Domain.Commands.Command.Exam;
using OnlineExam.Domain.Commands.Handler.Exam;
using OnlineExam.Domain.Queries.Handler.Course;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query.Exam;
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
    public class SaveExamViewModel : BaseViewModel
    {
        private Models.Exam _exam;
        public Models.Exam Exam
        {
            get { return _exam; }
            set { SetProperty(ref _exam, value); }
        }

        public BindingList<Models.Course> Courses { get; set; }
        public BindingList<string> Errors { get; set; }

        public Command Command { get; set; }

        public SaveExamViewModel()
        {
            _exam = new Models.Exam();

            Courses = new BindingList<Models.Course>();
            Errors = new BindingList<string>();
            Command = new Command(SaveExam);

            GetCourses();
        }

        public SaveExamViewModel(Models.Exam exam)
        {
            Courses = new BindingList<Models.Course>();
            Errors = new BindingList<string>();
            Command = new Command(SaveExam);

            var query = new OneExamQuery(exam.ExamId);
            var handler = new OneExamQueryHandler(query);
            var result = handler.Get();

            if (result != null)
            {
                _exam = new Models.Exam()
                {
                    ExamId = result.ExamId,
                    ExamName = result.ExamName,
                    MinRequirement = result.MinRequirement,
                    Course = result.Course,
                    TimeSlot = result.TimeSlot,
                    Questions = new BindingList<Models.Question>(result.Questions.ToList()),
                };
                result = null;
            }
            else
            {
                Errors.Add("There is no exam!");
            }

            GetCourses();
        }

        private void SaveExam()
        {
            IsBusy = true;

            Errors.Clear();

            var command = new SaveExamCommand(_exam);
            var handler = new SaveExamCommandHandler(command);
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

        public void GetCourses()
        {
            IsBusy = true;

            var handler = new AllCoursesQueryHandler();
            var courses = handler.Get();

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

        public void RemoveQuestion(Models.Question question)
        {
            Exam.Questions.Remove(question);
        }

        public void AddAnswer(Models.Question question)
        {
            question.Answers.Add(new Models.Answer() { Question = question });
        }

        public void AddQuestion()
        {
            Exam.Questions.Add(new Models.Question());
        }

        internal void RemoveAnswer(Models.Question question, Models.Answer answer)
        {
            question.Answers.Remove(answer);
        }

        public void SetStartTime(TimeSpan timespan)
        {
            Exam.TimeSlot.StartTime = timespan;
        }

        public void SetDate(DateTime date)
        {
            Exam.TimeSlot.Date = date;
        }

        public void SetEndTime(TimeSpan timespan)
        {
            Exam.TimeSlot.EndTime = timespan;
        }
    }
}
