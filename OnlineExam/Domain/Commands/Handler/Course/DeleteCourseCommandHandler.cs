using OnlineExam.Context;
using OnlineExam.Domain.Commands.Command.Course;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Handler.Course
{
    public class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand, CommandResponse>
    {
        private DeleteCourseCommand _command;

        public DeleteCourseCommandHandler(DeleteCourseCommand command)
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
                    var item = context.Courses.FirstOrDefault(d => d.CourseId == _command.ID);

                    if (item == null)
                    {
                        response.Message = "This item doesn't exist!";
                    }
                    else
                    {
                        context.Courses.Remove(item);
                        context.SaveChanges();

                        response.ID = item.CourseId;
                        response.Message = "Course deleted successfully!";
                        response.Success = true;
                    }
                }
                catch
                {
                    response.Message = "Couldn't delete Course!";
                }
            }

            return response;
        }
    }
}
