using Roomy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Validators
{
    public class UserMailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                var db = (RoomyDbContext)validationContext.GetService(typeof(RoomyDbContext));
                if (db.Users.Any(x => x.Mail == value.ToString()))
                    return new ValidationResult("Mail existant");
                else
                    return ValidationResult.Success;
            }
            return ValidationResult.Success;

        }
    }
}
