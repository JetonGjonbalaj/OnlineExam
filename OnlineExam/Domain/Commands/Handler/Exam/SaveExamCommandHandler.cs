using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Exam;
using OnlineExam.Domain.Queries.Handler.Exam;
using OnlineExam.Domain.Queries.Query.Exam;
using OnlineExam.Interfaces;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Exam
{
    public class SaveExamCommandHandler : ICommandHandler<SaveExamCommand, CommandResponse>
    {
        private SaveExamCommand _command;

        public SaveExamCommandHandler(SaveExamCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            ExamValidator validator = new ExamValidator();
            ValidationResult result = validator.Validate(_command.Exam);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Message += failure.ErrorMessage;
                }
                return response;
            }

            using (var context = new DatabaseContext())
            {
                try
                {
                    var item = context.Exams.Include(e => e.TimeSlot).Include(e => e.Questions).ThenInclude(q => q.Answers).FirstOrDefault(d => d.ExamId == _command.Exam.ExamId);

                    if (item == null)
                    {
                        context.Attach(_command.Exam.Course);
                        context.Exams.Add(_command.Exam);
                        response.Message = "Exam added successfully!";
                    }
                    else
                    {
                        try
                        {
                            context.Attach(_command.Exam.Course);
                        }
                        catch { }
                        try
                        {
                            context.Attach(_command.Exam.TimeSlot);
                        }
                        catch { }
                        try
                        {
                            context.Attach(_command.Exam.Questions);
                        }
                        catch { }

                        item.Course = _command.Exam.Course;
                        item.TimeSlot.Date = _command.Exam.TimeSlot.Date;
                        item.TimeSlot.StartTime = _command.Exam.TimeSlot.StartTime;
                        item.TimeSlot.EndTime = _command.Exam.TimeSlot.EndTime;

                        item.Questions.Clear();
                        item.Questions = _command.Exam.Questions;

                        context.Entry(item).CurrentValues.SetValues(_command.Exam);
                        response.Message = "Exam updated successfully!";
                    }

                    context.SaveChanges();

                    response.ID = _command.Exam.ExamId;
                    response.Success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    response.Message = "Coudn't save Exam!";
                }
            }

            return response;
        }
    }
}
