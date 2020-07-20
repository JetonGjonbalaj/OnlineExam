using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Professor
{
    public class SaveProfessorCommand : ICommand<CommandResponse>
    {
        public Models.Professor Professor { get; private set; }
        public SaveProfessorCommand(Models.Professor professor)
        {
            Professor = professor;
        }
    }
}
