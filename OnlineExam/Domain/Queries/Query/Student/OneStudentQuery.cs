using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Student
{
    public class OneStudentQuery : IQuery<Models.Student>
    {
        public int ID { get; private set; }
        public OneStudentQuery(int id)
        {
            ID = id;
        }
    }
}
