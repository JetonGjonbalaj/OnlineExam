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
    public class OneExamQueryHandler : IQueryHandler<OneExamQuery, Models.Exam>
    {
        private readonly OneExamQuery _query;

        public OneExamQueryHandler(OneExamQuery query)
        {
            _query = query;
        }

        public Models.Exam Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Exams.Include(e => e.Course)
                                    .Include(e => e.TimeSlot)
                                    .Include(e => e.Questions)
                                    .ThenInclude(e => e.Answers)
                                    .FirstOrDefault(e => e.ExamId == _query.ID);
            }
        }
    }
}
