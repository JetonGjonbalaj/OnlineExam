using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Exam
{
    public class OneExamQuery : IQuery<Models.Exam>
    {
        public int ID { get; private set; }
        public OneExamQuery(int id)
        {
            ID = id;
        }
    }
}
