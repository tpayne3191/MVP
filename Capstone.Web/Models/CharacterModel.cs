using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capstone.Core.Entities;

namespace Capstone.Web.Models
{
    public class CharacterModel
    {
        // IDs
        [Key]
        public int Id { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int CampaignId { get; set; }

        // About 
        [Required]
        public int Level { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public int ArmorClass { get; set; }
        [Required]
        public int HitPoints { get; set; }
        [Required]
        [MaxLength(50)]
        public string Race { get; set; }
        [Required]
        [MaxLength(50)]
        public string Alignment { get; set; }
        [Required]
        [MaxLength(50)]
        public string Class { get; set; }
        [Required]
        [MaxLength(250)]
        public string Image { get; set; }

        // Stats
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
    }
}
