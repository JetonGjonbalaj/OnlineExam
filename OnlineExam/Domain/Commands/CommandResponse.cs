using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Commands
{
    public class CommandResponse
    {
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
