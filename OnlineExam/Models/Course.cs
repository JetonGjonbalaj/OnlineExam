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
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        public Department Department { get; set; }
        public ICollection<Professor> Professors { get; set; } = new List<Professor>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
