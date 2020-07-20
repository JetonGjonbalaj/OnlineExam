using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Student;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.Student
{
    public class AllStudentsQueryHandle : IQueryHandler<AllStudentsQuery, IEnumerable<Models.Student>>
    {
        public IEnumerable<Models.Student> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Students.ToList();
            }
        }
    }
}
