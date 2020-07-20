using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(e => e.ExamName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.ExamNameLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.ExamNameLength + "!");

            RuleFor(e => e.Course)
                .NotEmpty().WithMessage("{PropertyName} is empty!");

            RuleFor(e => e.TimeSlot)
                .NotEmpty().WithMessage("{PropertyName} is empty!");

            RuleFor(e => e.TimeSlot.EndTime)
                .GreaterThan(e => e.TimeSlot.StartTime).WithMessage("End time should not be less or equal to start time!");

            RuleFor(e => e.Questions)
                .Custom((questions, context) =>
                {
                    if (questions.Count == 0)
                    {
                        context.AddFailure("You should add some questions!");
                        return;
                    }

                    foreach (var question in questions)
                    {
                        if (question.QuestionText == null)
                        {
                            context.AddFailure("There is a question without text!");
                            return;
                        }
                        else if (question.QuestionText.Length == 0 || question.QuestionText.Length > ValidationProperties.QuestionTextLength)
                        {
                            context.AddFailure($"Your question text should be between 1 and ${ValidationProperties.QuestionTextLength}!");
                            return;
                        }
                        else if (question.Answers.Count == 0)
                        {
                            context.AddFailure("There is a question without answers!");
                            return;
                        }

                        var answers = new List<Answer>(question.Answers);
                        var emtpyAnswer = answers.Find(a => string.IsNullOrEmpty(a.AnswerText));
                        if (emtpyAnswer != null)
                        {
                            context.AddFailure("There is an answer without text!");
                            return;
                        }

                        var trueAnswer = answers.Find(a => a.IsTrue);
                        if (trueAnswer == null)
                        {
                            context.AddFailure("There is a question without a correct answer!");
                            return;
                        }
                    }
                });
        }
    }
}
