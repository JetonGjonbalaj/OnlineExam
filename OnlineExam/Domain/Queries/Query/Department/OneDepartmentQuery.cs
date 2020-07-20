using OnlineExam.Interfaces;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query
{
    public class OneDepartmentQuery : IQuery<Department>
    {
        public int ID { get; private set; }
        public OneDepartmentQuery(int id)
        {
            ID = id;
        }
    }
}
