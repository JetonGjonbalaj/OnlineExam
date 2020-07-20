using FluentValidation.Results;
using OnlineExam.Domain.Commands.Command.ExamTaken;
using OnlineExam.Domain.Commands.Handler.ExamTaken;
using OnlineExam.Domain.Queries.Handler.Answer;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query.Answer;
using OnlineExam.Domain.Queries.Query.Exam;
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

namespace OnlineExam.ViewModels.User.Exam
{
    public class TakeExamViewModel : BaseViewModel
    {
        private Models.ExamTaken _examTaken;
        public Models.Exam Exam { get; set; }
        public BindingList<string> Errors { get; set; }
        public ICommand Command { get; set; }

        public TakeExamViewModel(Models.ExamTaken examTaken)
        {
            _examTaken = examTaken;

            var query = new OneExamQuery(examTaken.Exam.ExamId);
            var handler = new OneExamQueryHandler(query);
            var result = handler.Get();

            if (result == null)
            {
                Errors.Add("There was a problem with the exam! Please, try again.");
            }
            else
            {
                Errors = new BindingList<string>();
                Command = new Command(() => FinishTest());
                Exam = new Models.Exam() { ExamId = result.ExamId, ExamName = result.ExamName, Course = result.Course, TimeSlot = result.TimeSlot, MinRequirement = result.MinRequirement };

                foreach (var question in result.Questions)
                {
                    var newQuestion = new Models.Question() { QuestionId = question.QuestionId, QuestionText = question.QuestionText };

                    foreach(var answer in question.Answers)
                    {
                        var newAnswer = new Models.Answer() { AnswerId = answer.AnswerId, AnswerText = answer.AnswerText, IsTrue = false };

                        newQuestion.Answers.Add(newAnswer);
                    }

                    Exam.Questions.Add(newQuestion);
                }
            }
        }

        private void FinishTest()
        {
            Errors.Clear();

            if (_examTaken.Status == Enums.ExamStatus.Passed || _examTaken.Status == Enums.ExamStatus.Failed)
            {
                MessageBox.Show("Exam already finished!");
                return;
            }

            ExamValidator validator = new ExamValidator();
            ValidationResult result = validator.Validate(Exam);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Errors.Add(failure.ErrorMessage);
                }
                return;
            }

            var points = 0;

            foreach(var question in Exam.Questions)
            {
                var answerQuery = new OneCorrectAnswerQuery(question.QuestionId);
                var answerHandler = new OneCorrectAnswerQueryHandler(answerQuery);
                var trueAnswer = answerHandler.Get();

                var userAnswer = question.Answers.Where(a => a.IsTrue == true).First();

                if (userAnswer.AnswerId == trueAnswer.AnswerId)
                    points++;
            }

            int pointsPercentage = 100 * points / Exam.Questions.Count;

            _examTaken.Result = pointsPercentage;
            _examTaken.Status = pointsPercentage >= Exam.MinRequirement ? Enums.ExamStatus.Passed : Enums.ExamStatus.Failed;

            var command = new SaveExamTakenCommand(_examTaken);
            var handler = new SaveExamTakenCommandHandler(command);
            var examTakenResult = handler.Execute();

            if (examTakenResult.Success)
            {
                MessageBox.Show("Exam saved successfuly!\nYou can see your results now!");
            }
            else
            {
                MessageBox.Show(examTakenResult.Message);
            }
        }
    }
}
