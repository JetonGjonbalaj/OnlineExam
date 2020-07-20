using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Exam
    {
        public Exam()
        {
            MinRequirement = 50;
        }

        [Key]
        public int ExamId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ExamName { get; set; }
        [Required]
        public int MinRequirement { get; set; }

        public Course Course { get; set; }
        public TimeSlot TimeSlot { get; set; } = new TimeSlot();
        public ICollection<Question> Questions { get; set; } = new BindingList<Question>();
    }
}
