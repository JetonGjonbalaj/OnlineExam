using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; } = DateTime.Today;
        [Required]
        public TimeSpan StartTime { get; set; } = DateTime.Now.TimeOfDay;
        [Required]
        public TimeSpan EndTime { get; set; } = DateTime.Now.TimeOfDay;

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
