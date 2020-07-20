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
    public class OneCourseQueryHandler : IQueryHandler<OneCourseQuery, Models.Course>
    {
        private readonly OneCourseQuery _query;

        public OneCourseQueryHandler(OneCourseQuery query)
        {
            _query = query;
        }

        public Models.Course Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Courses.Include(c => c.Department).FirstOrDefault(c => c.CourseId == _query.ID);
            }
        }
    }
}
