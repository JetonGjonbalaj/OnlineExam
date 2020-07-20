using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Exam;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.Exam
{
    public class AllAvailableExamsQueryHandler : IQueryHandler<AllExamsQuery, IEnumerable<Models.Exam>>
    {
        public IEnumerable<Models.Exam> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Exams.Include(e => e.Course)
                                    .Include(e => e.TimeSlot)
                                    .Where(e =>
                                        e.TimeSlot.Date >= DateTime.Today &&
                                        e.TimeSlot.StartTime > DateTime.Now.TimeOfDay)
                                    .ToList();
            }
        }
    }
}
