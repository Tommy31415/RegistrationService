using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace RegistrationService.Models
{
    public class Customer : IValidatableObject
    {
        public long Id { get; set; }
        [Required]
        [EnumDataType(typeof(EVendor))]
        [JsonConverter(typeof(StringEnumConverter<,,>))]
        public EVendor Vendor { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Additional { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Additional != string.Empty) yield break;
            switch (Vendor)
            {
                case EVendor.MrGreen:
                    yield return new ValidationResult("Phone number is required");
                    break;
                case EVendor.RedBet:
                    yield return new ValidationResult("Favorite football team is required.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
