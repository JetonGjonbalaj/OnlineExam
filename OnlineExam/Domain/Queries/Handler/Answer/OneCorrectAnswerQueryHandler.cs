using OnlineExam.Context;
using OnlineExam.Domain.Queries.Query.Answer;
using OnlineExam.Domain.Queries.Query.Course;
using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Handler.Answer
{
    public class OneCorrectAnswerQueryHandler : IQueryHandler<OneCorrectAnswerQuery, Models.Answer>
    {
        private readonly OneCorrectAnswerQuery _query;

        public OneCorrectAnswerQueryHandler(OneCorrectAnswerQuery query)
        {
            _query = query;
        }

        public Models.Answer Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Answers.Where(a => a.Question.QuestionId == _query.QuestionId && a.IsTrue == true).FirstOrDefault();
            }
        }
    }
}
