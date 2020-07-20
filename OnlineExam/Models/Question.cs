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
    public class Question
    {
        public Question()
        {
            RandomGroupName = Guid.NewGuid();
        }
        [Key]
        public int QuestionId { get; set; }
        [MaxLength(511)]
        [Required]
        public string QuestionText { get; set; }
        // This one is used to group radiobuttons and therefore it doesn't go to database
        [NotMapped]
        public Guid RandomGroupName { get; set; }

        public Exam Exam { get; private set; }
        public ICollection<Answer> Answers { get; set; } = new BindingList<Answer>();
    }
}
