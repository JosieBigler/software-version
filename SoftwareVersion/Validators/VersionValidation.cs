using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SoftwareVersion.Validators
{
    public class VersionValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var acceptableCharacters = new List<char>
            {
                '0',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9',
                '.'
            };

            for (int i = 1; i < value.ToString().Length; i++)
            {
                var prev = value.ToString()[i - 1];
                var current = value.ToString()[i];

                if (prev == '.' && current == '.')
                {
                    return new ValidationResult("Incorrect Version format! Please seperate your decimals with a number \"..\" is incorrect. \".0.\" is correct");
                }
            }

            if (value.ToString().All(c => acceptableCharacters.Contains(c)))
                return ValidationResult.Success;

            return new ValidationResult("Incorrect Version format! Only numbers and decimals please.");
        }
    }
}
