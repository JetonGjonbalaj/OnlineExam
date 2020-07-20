using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Student
{
    public class SaveStudentCommand : ICommand<CommandResponse>
    {
        public Models.Student Student { get; private set; }
        public SaveStudentCommand(Models.Student student)
        {
            Student = student;
        }
    }
}
