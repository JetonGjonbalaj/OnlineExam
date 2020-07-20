using OnlineExam.Enums;
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
    public class ExamTaken
    {
        [Key]
        public int ExamTakenId { get; set; }
        //[Column(TypeName="decimal(3,2)")]
        public int Result { get; set; }
        public ExamStatus Status { get; set; }

        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}
