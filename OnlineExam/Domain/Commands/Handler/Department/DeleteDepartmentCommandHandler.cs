using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Department;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Department
{
    public class DeleteDepartmentCommandHandler : ICommandHandler<DeleteDepartmentCommand, CommandResponse>
    {
        private DeleteDepartmentCommand _command;

        public DeleteDepartmentCommandHandler(DeleteDepartmentCommand command)
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
                    var item = context.Departments.FirstOrDefault(d => d.DepartmentId == _command.ID);

                    if (item == null)
                    {
                        response.Message = "This item doesn't exist!";
                    }
                    else
                    {
                        context.Departments.Remove(item);
                        context.SaveChanges();

                        response.ID = item.DepartmentId;
                        response.Message = "Department deleted successfully!";
                        response.Success = true;
                    }
                }
                catch (Exception e)
                {
                    response.Message = e.Message;
                    //response.Message = "Couldn't delete department!";
                }
            }

            return response;
        }
    }
}
