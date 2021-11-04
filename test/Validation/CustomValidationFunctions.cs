using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Validators
{
    public static class CustomValidationFunctions
    {
        public static bool BeAllLetter(string input)
        {
            return input.All(Char.IsLetter);
        }
    }
}
