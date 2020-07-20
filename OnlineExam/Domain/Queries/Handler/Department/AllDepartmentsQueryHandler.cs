using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query;
using OnlineExam.Interfaces;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler
{
    public class AllDepartmentsQueryHandler : IQueryHandler<AllDepartmentsQuery, IEnumerable<Department>>
    {
        public IEnumerable<Department> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Departments.ToList();
            }
        }
    }
}
