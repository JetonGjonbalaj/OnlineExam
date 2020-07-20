using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.ExamTaken
{
    public class AllActiveExamTakenQuery : IQuery<IEnumerable<Models.ExamTaken>>
    {
        public Models.Student Student { get; set; }

        public AllActiveExamTakenQuery(Models.Student student)
        {
            Student = student;
        }
    }
}
