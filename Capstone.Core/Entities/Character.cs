using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        // ---------------------------------------------- ABOUT ---------------------------------------------- 
        [Required]
        [Range(1, 20, ErrorMessage = "Level must be between 1 and 20.")]
        public int Level { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Race must be valid string between 0 - 50 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(1, 49, ErrorMessage = "Armor Class cannot be less than 0 or greater than 49 (Highest Possible).")]
        public int ArmorClass { get; set; }

        [Required]
        [Range(1, 620, ErrorMessage = "Hit points cannot be less than 0 or greater than 620 (Highest Possible).")]
        public int HitPoints { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Race must be valid string between 0 - 50 characters.")]
        public string Race { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Alignment must be valid string between 0 - 50 characters.")]
        public string Alignment { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Class must be valid string between 0 - 50 characters.")]
        public string Class { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Image URL must be valid URL between 0 - 250 characters.")]
        public string Image { get; set; }

        // ---------------------------------------------- STATS ---------------------------------------------- 
        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Strength { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Dexterity { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Constitution { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Intelligence { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Wisdom { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stat must be between 1 and 20.")]
        public int Charisma { get; set; }

        // Parent Connectors - Entity Framework
        [Required]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [Required]
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        // Bridge Connectors - Entity Framework
        public List<CharacterWeapon> CharacterWeapons { get; set; }
    }
}