using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Student;
using OnlineExam.Interfaces;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Student
{
    public class SaveStudentCommandHandler : ICommandHandler<SaveStudentCommand, CommandResponse>
    {
        private SaveStudentCommand _command;

        public SaveStudentCommandHandler(SaveStudentCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            StudentValidator validator = new StudentValidator();
            ValidationResult result = validator.Validate(_command.Student);

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
                    var emailExist = context.Students.Where(s => s.UserId != _command.Student.UserId && s.Email == _command.Student.Email).FirstOrDefault();
                    var idExist = context.Students.Where(s => s.UserId != _command.Student.UserId && s.StudentId == _command.Student.StudentId).FirstOrDefault();

                    if (emailExist != null)
                    {
                        response.Message = "Email already exist!";
                    }
                    else if (idExist != null)
                    {
                        response.Message = "StudentId already exist!";
                    }
                    else
                    {
                        var item = context.Students.FirstOrDefault(d => d.UserId == _command.Student.UserId);

                        if (item == null)
                        {
                            context.Entry(_command.Student).State = EntityState.Added;
                            response.Message = "Student added successfully!";
                        }
                        else
                        {
                            try
                            {
                                context.Attach(_command.Student.Department);
                            }
                            catch { }

                            item.Department = _command.Student.Department;
                            context.Entry(item).CurrentValues.SetValues(_command.Student);

                            response.Message = "Student updated successfully!";
                        }

                        context.SaveChanges();

                        response.ID = _command.Student.UserId;
                        response.Success = true;
                    }
                }
                catch
                {
                    response.Message = "Coudn't save Student!";
                }
            }

            return response;
        }
    }
}
