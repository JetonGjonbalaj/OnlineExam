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
    class AllStudentUpcomingExamsQueryHanlder : IQueryHandler<AllStudentUpcomingExamsQuery, IEnumerable<Models.Exam>>
    {
        private readonly AllStudentUpcomingExamsQuery _query;

        public AllStudentUpcomingExamsQueryHanlder(AllStudentUpcomingExamsQuery query)
        {
            _query = query;
        }

        public IEnumerable<Models.Exam> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Exams.Include(e => e.TimeSlot)
                                    .Where(e => 
                                        e.Course.Department.DepartmentId == _query.StudentDepartmentID && 
                                        e.TimeSlot.Date >= DateTime.Today && 
                                        e.TimeSlot.StartTime > DateTime.Now.TimeOfDay)
                                    .ToList();
            }
        }
    }
}
