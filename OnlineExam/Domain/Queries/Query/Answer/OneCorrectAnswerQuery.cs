using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Answer
{
    public class OneCorrectAnswerQuery : IQuery<Models.Answer>
    {
        public int QuestionId { get; set; }
        public OneCorrectAnswerQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
