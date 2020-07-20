using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Course;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.Course
{
    public class AllCoursesQueryHandler : IQueryHandler<AllCoursesQuery, IEnumerable<Models.Course>>
    {
        public IEnumerable<Models.Course> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Courses.ToList();
            }
        }
    }
}
