using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Professor
{
    public class OneProfessorQuery : IQuery<Models.Professor>
    {
        public int ID { get; private set; }
        public OneProfessorQuery(int id)
        {
            ID = id;
        }
    }
}
