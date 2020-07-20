using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Professor
{
    public class DeleteProfessorCommand : ICommand<CommandResponse>
    {
        public int ID { get; private set; }
        public DeleteProfessorCommand(int id)
        {
            ID = id;
        }
    }
}
