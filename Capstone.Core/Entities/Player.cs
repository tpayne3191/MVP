using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name must be between 0 - 50 characters.")]
        public string Name { get; set; }
        
        [MaxLength(50, ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } 
        
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Email address cannot exceed 50 characters.")]
        public string Email { get; set; }
        
        [MaxLength(50, ErrorMessage = "City must be between 0 - 50 characters.")]
        public string City { get; set; }

        // Child Connectors - Entity Framework
        public List<Character> Characters { get; set; }
    }
}
