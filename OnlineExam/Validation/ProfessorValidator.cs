using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class ProfessorValidator : UserValidator<Professor>
    {
        public ProfessorValidator() : base()
        {
            RuleFor(s => s.ProfessorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.ProfessorIdLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.ProfessorIdLength + "!");
        }
    }
}
