using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class StudentValidator : UserValidator<Student>
    {
        public StudentValidator() : base()
        {
            RuleFor(s => s.StudentId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.StudentIdLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.StudentIdLength + "!");
        }
    }
}
