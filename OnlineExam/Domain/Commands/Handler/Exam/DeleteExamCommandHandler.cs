using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Exam;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Exam
{
    public class DeleteExamCommandHandler : ICommandHandler<DeleteExamCommand, CommandResponse>
    {
        private DeleteExamCommand _command;

        public DeleteExamCommandHandler(DeleteExamCommand command)
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
                    var item = context.Exams.FirstOrDefault(d => d.ExamId == _command.ID);

                    if (item == null)
                    {
                        response.Message = "This item doesn't exist!";
                    }
                    else
                    {
                        context.Exams.Remove(item);
                        context.SaveChanges();

                        response.ID = item.ExamId;
                        response.Message = "Exam deleted successfully!";
                        response.Success = true;
                    }
                }
                catch
                {
                    response.Message = "Couldn't delete Exam!";
                }
            }

            return response;
        }
    }
}
