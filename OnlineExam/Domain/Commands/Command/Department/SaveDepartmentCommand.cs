using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Department
{
    public class SaveDepartmentCommand : ICommand<CommandResponse>
    {
        public Models.Department Department { get; private set; }
        public SaveDepartmentCommand(Models.Department department)
        {
            Department = department;
        }
    }
}
