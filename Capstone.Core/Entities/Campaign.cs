using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Campaign : IValidatableObject
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

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
