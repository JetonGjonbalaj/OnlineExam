using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Student
{
    public class LoginStudentQuery : IQuery<Models.Student>
    {
        public string Email { get; private set; }
        public LoginStudentQuery(string email)
        {
            Email = email;
        }
    }
}
