using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Contact : IValidatableObject
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string Vin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationResult("Please enter your name",
                    new[] { "Name" }));
            }

            if (string.IsNullOrEmpty(Message))
            {
                errors.Add(new ValidationResult("Please enter message",
                    new[] { "Message" }));
            }

            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {
                errors.Add(new ValidationResult("Please enter either email or phone",
                    new[] { "Email Or Phone" }));
            }

            return errors;
        }
    }
}