using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.ExamTaken;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.ExamTaken
{
    public class SaveExamTakenCommandHandler : ICommandHandler<SaveExamTakenCommand, CommandResponse>
    {
        private SaveExamTakenCommand _command;

        public SaveExamTakenCommandHandler(SaveExamTakenCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            using (var context = new DatabaseContext())
            {
                try
                {
                    var item = context.ExamsTaken.FirstOrDefault(et => 
                                                                    et.Exam.ExamId == _command.ExamTaken.Exam.ExamId && 
                                                                    et.Student.UserId == _command.ExamTaken.Student.UserId);

                    if (item == null)
                    {
                        context.Entry(_command.ExamTaken).State = EntityState.Added;
                        response.Message = "Exam taken successfully!";
                    }
                    else
                    {
                        var itemExist = context.ExamsTaken.FirstOrDefault(et => et.ExamTakenId == _command.ExamTaken.ExamTakenId);

                        if (itemExist != null)
                        {
                            context.Entry(itemExist).CurrentValues.SetValues(_command.ExamTaken);
                            response.Message = $"Taken exam updated!";
                        }
                        else
                        {
                            response.Message = $"You already took {_command.ExamTaken.Exam.ExamName}!";
                            return response;
                        }
                    }

                    context.SaveChanges();

                    response.ID = _command.ExamTaken.ExamTakenId;
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
