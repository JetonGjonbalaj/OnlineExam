using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Professor;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Professor
{
    public class DeleteProfessorCommandHandler : ICommandHandler<DeleteProfessorCommand, CommandResponse>
    {
        private DeleteProfessorCommand _command;

        public DeleteProfessorCommandHandler(DeleteProfessorCommand command)
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
                    var item = context.Professors.FirstOrDefault(d => d.UserId == _command.ID);

                    if (item == null)
                    {
                        response.Message = "This item doesn't exist!";
                    }
                    else
                    {
                        context.Professors.Remove(item);
                        context.SaveChanges();

                        response.ID = item.UserId;
                        response.Message = "Professor deleted successfully!";
                        response.Success = true;
                    }
                }
                catch
                {
                    response.Message = "Couldn't delete Professor!";
                }
            }

            return response;
        }
    }
}
