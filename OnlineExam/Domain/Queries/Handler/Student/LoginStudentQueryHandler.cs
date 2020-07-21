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
    public class LoginStudentQueryHandler : IQueryHandler<LoginStudentQuery, Models.Student>
    {
        private readonly LoginStudentQuery _query;

        public LoginStudentQueryHandler(LoginStudentQuery query)
        {
            _query = query;
        }

        public Models.Student Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Students.Include(s => s.Department).Include(s => s.ExamsTaken).FirstOrDefault(s => s.Email == _query.Email);
            }
        }
    }
}
