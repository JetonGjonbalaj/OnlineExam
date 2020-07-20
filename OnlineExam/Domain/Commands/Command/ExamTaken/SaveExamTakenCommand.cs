using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands.Command.ExamTaken
{
    public class SaveExamTakenCommand : ICommand<CommandResponse>
    {
        public Models.ExamTaken ExamTaken { get; set; }
        public SaveExamTakenCommand(Models.ExamTaken examTaken)
        {
            ExamTaken = examTaken;
        }
    }
}
