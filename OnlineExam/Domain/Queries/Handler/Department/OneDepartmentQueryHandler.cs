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
    public class OneDepartmentQueryHandler : IQueryHandler<OneDepartmentQuery, Department>
    {
        private readonly OneDepartmentQuery _query;

        public OneDepartmentQueryHandler(OneDepartmentQuery query)
        {
            _query = query;
        }

        public Department Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Departments.FirstOrDefault(d => d.DepartmentId == _query.ID);
            }
        }
    }
}
