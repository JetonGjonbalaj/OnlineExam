using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Student
{
    public class DeleteStudentCommand : ICommand<CommandResponse>
    {
        public int ID { get; private set; }
        public DeleteStudentCommand(int id)
        {
            ID = id;
        }
    }
}
