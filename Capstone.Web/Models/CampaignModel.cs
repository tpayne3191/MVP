using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class CampaignModel
    {
        [Key]
        public int CampaignId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
    }
}
