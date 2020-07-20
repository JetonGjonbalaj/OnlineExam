using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Professor;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineExam.Domain.Queries.Handler.Professor
{
    public class AllProfessorsQueryHandler : IQueryHandler<AllProfessorsQuery, IEnumerable<Models.Professor>>
    {
        public IEnumerable<Models.Professor> Get()
        {
            using (var context = new DatabaseContext())
            {
                var userId = ((App)Application.Current).LoggedUser.UserId;
                return context.Professors.Where(p => p.UserId != userId).ToList();
            }
        }
    }
}
