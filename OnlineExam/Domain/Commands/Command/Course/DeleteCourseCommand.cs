using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Course
{
    public class DeleteCourseCommand : ICommand<CommandResponse>
    {
        public int ID { get; private set; }
        public DeleteCourseCommand(int id)
        {
            ID = id;
        }
    }
}
