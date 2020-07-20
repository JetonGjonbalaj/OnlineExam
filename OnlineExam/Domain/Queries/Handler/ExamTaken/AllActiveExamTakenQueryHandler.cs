using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.ExamTaken;
using OnlineExam.Enums;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.ExamTaken
{
    public class AllActiveExamTakenQueryHandler : IQueryHandler<AllActiveExamTakenQuery, IEnumerable<Models.ExamTaken>>
    {
        private AllActiveExamTakenQuery _query;

        public AllActiveExamTakenQueryHandler(AllActiveExamTakenQuery query)
        {
            _query = query;
        }

        public IEnumerable<Models.ExamTaken> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.ExamsTaken.Include(et => et.Student)
                                         .Include(et => et.Exam.TimeSlot)
                                         .Where(et => et.Student.UserId == _query.Student.UserId
                                                && (et.Status == ExamStatus.Taken || et.Status == ExamStatus.Pending)
                                                && et.Exam.TimeSlot.Date == DateTime.Today
                                                && et.Exam.TimeSlot.StartTime <= DateTime.Now.TimeOfDay
                                                && et.Exam.TimeSlot.EndTime >= DateTime.Now.TimeOfDay).ToList();
            }
        }
    }
}
