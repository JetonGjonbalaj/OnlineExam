using OnlineExam.Context;
using OnlineExam.Interfaces;
using OnlineExam.Domain.Commands.Command.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Student
{
    public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand, CommandResponse>
    {
        private DeleteStudentCommand _command;

        public DeleteStudentCommandHandler(DeleteStudentCommand command)
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
                    var item = context.Students.FirstOrDefault(d => d.UserId == _command.ID);

                    if (item == null)
                    {
                        response.Message = "This item doesn't exist!";
                    }
                    else
                    {
                        context.Students.Remove(item);
                        context.SaveChanges();

                        response.ID = item.UserId;
                        response.Message = "Student deleted successfully!";
                        response.Success = true;
                    }
                }
                catch
                {
                    response.Message = "Couldn't delete Student!";
                }
            }

            return response;
        }
    }
}
