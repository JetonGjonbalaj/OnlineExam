using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.Exam
{
    public class SaveExamCommand : ICommand<CommandResponse>
    {
        public Models.Exam Exam { get; private set; }
        public SaveExamCommand(Models.Exam exam)
        {
            Exam = exam;
        }
    }
}
