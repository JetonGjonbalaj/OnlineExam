using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Course;
using OnlineExam.Interfaces;
using OnlineExam.Models;
using OnlineExam.Services;
using OnlineExam.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Course
{
    public class SaveCourseCommandHandler : ICommandHandler<SaveCourseCommand, CommandResponse>
    {
        private SaveCourseCommand _command;

        public SaveCourseCommandHandler(SaveCourseCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            CourseValidator validator = new CourseValidator();
            ValidationResult result = validator.Validate(_command.Course);

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
                    var item = context.Courses.FirstOrDefault(d => d.CourseId == _command.Course.CourseId);

                    if (item == null)
                    {
                        context.Entry(_command.Course).State = EntityState.Added;
                        response.Message = "Course added successfully!";
                    }
                    else
                    {
                        item.Department = _command.Course.Department;
                        context.Entry(item).CurrentValues.SetValues(_command.Course);
                        response.Message = "Course updated successfully!";
                    }

                    context.SaveChanges();

                    response.ID = _command.Course.CourseId;
                    response.Success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    response.Message = "Coudn't save Course!";
                }
            }

            return response;
        }
    }
}
