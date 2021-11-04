using FluentValidation;
using System;
using System.Linq;
using test.Models;

namespace ShopAPISourceCode.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.UserFirstName)
                .Must(BeAllLetter).WithMessage("only characters is valid in {PropertyName}")
                .MinimumLength(2).WithMessage("at least 2 chars for {PropertyName}")
                .MaximumLength(50).WithMessage("at most 50 chars for {PropertyName}");

            RuleFor(a => a.UserLastName)
                .Must(BeAllLetter).WithMessage("only characters is valid in {PropertyName}")
                .MinimumLength(2).WithMessage("at least 2 chars for {PropertyName}")
                .MaximumLength(50).WithMessage("at most 50 chars for {PropertyName}");

            RuleFor(a => a.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .EmailAddress().WithMessage("invalid format for {PropertyName}");

            RuleFor(a => a.UserPassword)
                .MinimumLength(8).WithMessage("at least 8 for {PropertyName}")
                .MaximumLength(50).WithMessage("at most 50 chars for {PropertyName}")
                .Must(HaveDiget).WithMessage("{PropertyName} must contain at least 1 diget")
                .Must(HaveLowerCaseLetter).WithMessage("{PropertyName} must contain lowrcase letter")
                .Must(HaveUpperCaseLetter).WithMessage("{PropertyName} must contain uppercase letter");

            RuleFor(a => a.UserSSN)
                .InclusiveBetween(1000000000, 9999999999).WithMessage("only 10 diget {PropertyName} is valid");
        }

        private bool HaveLowerCaseLetter(string input)
        {
            if (input.Any(char.IsLower) == false)
            {
                return false;
            }

            return true;
        }
        private bool HaveUpperCaseLetter(string input)
        {
            if (input.Any(char.IsUpper) == false)
            {
                return false;
            }

            return true;
        }


        private bool HaveDiget(string input)
        {
            if (input.Any(char.IsDigit) == false)
            {
                return false;
            }

            return true;
        }

        public static bool BeAllLetter(string input)
        {
            return input.All(Char.IsLetter);
        }
    }

}
