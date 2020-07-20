using Microsoft.EntityFrameworkCore;
using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.ExamTaken;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.ExamTaken
{
    public class AllFinishedExamsQueryHandler : IQueryHandler<AllFinishedExamsQuery, IEnumerable<Models.ExamTaken>>
    {
        private readonly AllFinishedExamsQuery _query;

        public AllFinishedExamsQueryHandler(AllFinishedExamsQuery query)
        {
            _query = query;
        }

        public IEnumerable<Models.ExamTaken> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.ExamsTaken.Include(et => et.Exam)
                                         .Where(et => et.Student.UserId == _query.Student.UserId
                                            && (et.Status == Enums.ExamStatus.Failed || et.Status == Enums.ExamStatus.Passed))
                                         .ToList();
            }
        }
    }
}
