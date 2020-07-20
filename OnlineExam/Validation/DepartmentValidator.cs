using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.DepartmentName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.DepartmentNameLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.DepartmentNameLength + "!")
                .Must(ValidationProperties.AreLetters).WithMessage("{PropertyName} contains invalid characters!");
        }
    }
}
