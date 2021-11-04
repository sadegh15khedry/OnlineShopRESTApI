using FluentValidation;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.AddressPostalCode)
                .GreaterThan(1000000000)
                .LessThan(9999999999)
                .WithMessage("only 10 diget {PropertyName} is valid");

            RuleFor(a => a.AddressState)
                .Must(BeAllLetter).WithMessage("only characters is valid in {PropertyName}");
        }
        public static bool BeAllLetter(string input)
        {
            return input.All(Char.IsLetter);
        }

    }
}
