using FluentValidation;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Validation
{
    public class UserValidator<TEntity> : AbstractValidator<TEntity> where TEntity : User
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.FirstNameLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.FirstNameLength + "!")
                .Must(ValidationProperties.AreLetters).WithMessage("{PropertyName} contains invalid characters!");

            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.LastNameLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.LastNameLength + "!")
                .Must(ValidationProperties.AreLetters).WithMessage("{PropertyName} contains invalid characters!");

            RuleFor(u => u.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.EmailLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.EmailLength + "!")
                .EmailAddress().WithMessage("Not a valid email!");

            RuleFor(u => u.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty!")
                .Length(1, ValidationProperties.PasswordLength).WithMessage("{PropertyName} should be between 1 and " + ValidationProperties.PasswordLength + "!");
        }
    }
}
