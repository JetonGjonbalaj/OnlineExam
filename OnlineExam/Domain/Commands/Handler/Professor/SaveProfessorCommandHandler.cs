using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Professor;
using OnlineExam.Interfaces;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Professor
{
    public class SaveProfessorCommandHandler : ICommandHandler<SaveProfessorCommand, CommandResponse>
    {
        private SaveProfessorCommand _command;

        public SaveProfessorCommandHandler(SaveProfessorCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            ProfessorValidator validator = new ProfessorValidator();
            ValidationResult result = validator.Validate(_command.Professor);

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
                    var emailExist = context.Professors.Where(p => p.UserId != _command.Professor.UserId && p.Email == _command.Professor.Email).FirstOrDefault();
                    var idExist = context.Professors.Where(p => p.UserId != _command.Professor.UserId && p.ProfessorId == _command.Professor.ProfessorId).FirstOrDefault();

                    if (emailExist != null)
                    {
                        response.Message = "Email already exist!";
                    }
                    else if (idExist != null)
                    {
                        response.Message = "ProfessorId already exist!";
                    }
                    else
                    {
                        var item = context.Professors.Include(p => p.Department).Include(p => p.Course).FirstOrDefault(d => d.UserId == _command.Professor.UserId);

                        if (item == null)
                        {
                            context.Entry(_command.Professor).State = EntityState.Added;
                            response.Message = "Professor added successfully!";
                        }
                        else
                        {
                            try
                            {
                                context.Attach(_command.Professor.Department);
                            }
                            catch { }
                            try
                            {
                                context.Attach(_command.Professor.Course);
                            }
                            catch { }

                            item.FirstName = _command.Professor.FirstName;
                            item.LastName = _command.Professor.LastName;
                            item.Password = _command.Professor.Password;
                            item.ProfessorId = _command.Professor.ProfessorId;
                            item.Email = _command.Professor.Email;
                            item.Department = _command.Professor.Department;
                            item.Course = _command.Professor.Course;
                            //context.Entry(item).CurrentValues.SetValues(_command.Professor);

                            response.Message = "Professor updated successfully!";
                        }

                        context.SaveChanges();

                        response.ID = _command.Professor.UserId;
                        response.Success = true;
                    }
                }
                catch (Exception e)
                {
                    response.Message = "Coudn't save Professor!";
                }
            }

            return response;
        }
    }
}
