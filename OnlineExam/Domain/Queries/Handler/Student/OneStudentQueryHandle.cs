using Microsoft.EntityFrameworkCore;
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
    public class OneStudentQueryHandle : IQueryHandler<OneStudentQuery, Models.Student>
    {
        private readonly OneStudentQuery _query;

        public OneStudentQueryHandle(OneStudentQuery query)
        {
            _query = query;
        }

        public Models.Student Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Students.Include(s => s.Department).Include(s => s.ExamsTaken).FirstOrDefault(s => s.UserId == _query.ID);
            }
        }
    }
}
