using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Student : User
    {
        public Student()
        {
            Role = Enums.Role.Student;
        }

        [Required]
        public bool IsCurrentStudent { get; set; }
        [Required]
        [MaxLength(10)]
        public string StudentId { get; set; }

        public Department Department { get; set; }
        public ICollection<ExamTaken> ExamsTaken { get; set; } = new List<ExamTaken>();
    }
}
