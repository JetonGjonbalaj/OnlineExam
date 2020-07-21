using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Professor;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.Professor
{
    public class LoginProfessorQueryHandler : IQueryHandler<OneProfessorQuery, Models.Professor>
    {
        private readonly LoginProfessorQuery _query;

        public LoginProfessorQueryHandler(LoginProfessorQuery query)
        {
            _query = query;
        }

        public Models.Professor Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Professors.Include(p => p.Department).Include(p => p.Course).FirstOrDefault(p => p.Email == _query.Email);
            }
        }
    }
}
