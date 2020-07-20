using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        [MaxLength(511)]
        public string AnswerText { get; set; }
        [Required]
        public bool IsTrue { get; set; }

        public Question Question { get; set; }
    }
}
