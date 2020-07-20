using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Exam
{
    public class DeleteExamCommand : ICommand<CommandResponse>
    {
        public int ID { get; private set; }
        public DeleteExamCommand(int id)
        {
            ID = id;
        }
    }
}
