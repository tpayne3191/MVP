using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Campaign : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateEnded { get; set; }

        // Child Connectors - Entity Framework
        public List<Character> Characters { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (DateEnded > DateStarted)
            {
                errors.Add(new ValidationResult("\"Date ended\" cannot be before \"date started\" entry.",
                    new[] { "DateStarted", "DateEnded" }));
            }

            return errors;
        }
    }
}
