using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
    }
}
