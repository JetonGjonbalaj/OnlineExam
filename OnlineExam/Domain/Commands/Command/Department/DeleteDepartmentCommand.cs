using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Department
{
    public class DeleteDepartmentCommand : ICommand<CommandResponse>
    {
        public int ID { get; private set; }
        public DeleteDepartmentCommand(int id)
        {
            ID = id;
        }
    }
}
