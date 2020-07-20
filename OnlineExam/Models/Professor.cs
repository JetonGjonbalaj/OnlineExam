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
    public class Professor : User
    {
        public Professor()
        {
            Role = Enums.Role.Professor;
        }

        [Required]
        [MaxLength(10)]
        public string ProfessorId { get; set; }

        public Course Course { get; set; }
        public Department Department { get; set; }
    }
}
