using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.CourseName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.CourseNameLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.CourseNameLength + "!")
                .Must(ValidationProperties.AreLetters).WithMessage("{PropertyName} contains invalid characters!");
        }
    }
}
