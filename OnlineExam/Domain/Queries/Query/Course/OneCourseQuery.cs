using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Course
{
    public class OneCourseQuery : IQuery<Models.Course>
    {
        public int ID { get; private set; }
        public OneCourseQuery(int id)
        {
            ID = id;
        }
    }
}
