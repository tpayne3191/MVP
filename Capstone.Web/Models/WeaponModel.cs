using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class WeaponModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
