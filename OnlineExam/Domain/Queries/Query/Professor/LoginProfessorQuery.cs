using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Professor
{
    public class LoginProfessorQuery : IQuery<Models.Professor>
    {
        public string Email { get; private set; }
        public LoginProfessorQuery(string email)
        {
            Email = email;
        }
    }
}
