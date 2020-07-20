using OnlineExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Queries.Query.Exam
{
    public class AllStudentUpcomingExamsQuery : IQuery<IEnumerable<Models.Exam>>
    {
        public int StudentDepartmentID { get; private set; }
        public AllStudentUpcomingExamsQuery(int studentDepartmentID)
        {
            StudentDepartmentID = studentDepartmentID;
        }
    }
}
