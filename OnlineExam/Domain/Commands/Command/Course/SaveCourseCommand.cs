using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Course
{
    public class SaveCourseCommand : ICommand<CommandResponse>
    {
        public Models.Course Course { get; private set; }
        public SaveCourseCommand(Models.Course course)
        {
            Course = course;
        }
    }
}
