using System;
using System.ComponentModel.DataAnnotations;

namespace Roomy.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AgeAttribute : ValidationAttribute
    {
        private int minimumAge;

        public AgeAttribute(int minimumAge)
        {
            this.minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if(value != null)
            {
                if(value is DateTime)
                {
                    return DateTime.Now.AddYears(-this.minimumAge) >= (DateTime)value;
                }
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, this.minimumAge);
        }
    }
}
