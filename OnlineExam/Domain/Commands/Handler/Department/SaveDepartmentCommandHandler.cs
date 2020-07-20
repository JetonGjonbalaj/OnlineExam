using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Department;
using OnlineExam.Interfaces;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Department
{
    public class SaveDepartmentCommandHandler : ICommandHandler<SaveDepartmentCommand, CommandResponse>
    {
        private SaveDepartmentCommand _command;

        public SaveDepartmentCommandHandler(SaveDepartmentCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            DepartmentValidator validator = new DepartmentValidator();
            ValidationResult result = validator.Validate(_command.Department);

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
                    var item = context.Departments.FirstOrDefault(d => d.DepartmentId == _command.Department.DepartmentId);

                    if (item == null)
                    {
                        context.Entry(_command.Department).State = EntityState.Added;
                        response.Message = "Department added successfully!";
                    } 
                    else
                    {
                        item.DepartmentName = _command.Department.DepartmentName;
                        response.Message = "Department updated successfully!";
                    }
                    
                    context.SaveChanges();

                    response.ID = _command.Department.DepartmentId;
                    response.Success = true;
                }
                catch
                {
                    response.Message = "Coudn't save department!";
                }
            }

            return response;
        }
    }
}
