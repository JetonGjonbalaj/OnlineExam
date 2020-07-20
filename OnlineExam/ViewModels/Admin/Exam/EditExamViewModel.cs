using FluentValidation.Results;
using OnlineExam.Context;
using OnlineExam.Models;
using OnlineExam.Services;
using OnlineExam.Utils;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlineExam.ViewModels.Admin.Exam
{
    public class EditExamViewModel : BaseViewModel
    {
        private DatabaseContext _context;
        private Models.Exam _exam;
        public Models.Exam Exam
        {
            get { return _exam; }
            set { SetProperty(ref _exam, value); }
        }
        public FallbackMessage CourseLoading { get; set; }
        private Models.Course _selectedCourse;
        public Models.Course SelectedCourse
        {
            get { return _selectedCourse; }
            set { SetProperty(ref _selectedCourse, value); }
        }
        public BindingList<Models.Course> Courses { get; set; }
        public ICommand Command { get; set; }
        public BindingList<string> Errors { get; set; }

        public EditExamViewModel(Models.Exam exam)
        {
            _context = ((App)Application.Current).Context;

            Exam = exam;
            Courses = new BindingList<Models.Course>();
            CourseLoading = new FallbackMessage() { Message = "Loading..." };
            Errors = new BindingList<string>();

            Command = new Command(() => EditExam());

            GetCourses();
        }

        public void RemoveQuestion(Question question)
        {
            Exam.Questions.Remove(question);
        }

        public void AddAnswer(Question question)
        {
            question.Answers.Add(new Models.Answer() { Question = question });
        }

        public void AddQuestion()
        {
            Exam.Questions.Add(new Models.Question());
        }

        internal void RemoveAnswer(Question question, Answer answer)
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

        private async Task EditExam()
        {
            Errors.Clear();

            if (SelectedCourse != null)
                _exam.Course = SelectedCourse;

            IsBusy = true;

            ExamValidator validator = new ExamValidator();
            ValidationResult result = validator.Validate(_exam);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Errors.Add(failure.ErrorMessage);
                }
                return;
            }

            RepositoryService<OnlineExam.Models.Exam> examService = new RepositoryService<OnlineExam.Models.Exam>(_context);

            var didUpdate= examService.Update(_exam);
            var didCommit = await examService.CommitAsync();

            if (didUpdate == null)
            {
                MessageBox.Show("Error updating data!");
            }
            else if (didCommit == 0)
            {
                MessageBox.Show("Error commiting data!");
            }
            else
            {
                MessageBox.Show("Exam updated successfully!");
            }

            IsBusy = false;
        }

        private async Task GetCourses()
        {
            IsBusy = true;
            CourseLoading.VisibleState = Visibility.Visible;

            RepositoryService<OnlineExam.Models.Course> courseService = new RepositoryService<OnlineExam.Models.Course>(_context);
            List<OnlineExam.Models.Course> courses = (await courseService.GetAsync()) as List<OnlineExam.Models.Course>;

            if (courses.Count == 0)
            {
                CourseLoading.Message = "There are no courses! Create one.";
            }
            else
            {
                foreach (var course in courses)
                {
                    try
                    {
                        Courses.Add(course);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                CourseLoading.VisibleState = Visibility.Hidden;
            }

            IsBusy = false;
        }
    }
}
