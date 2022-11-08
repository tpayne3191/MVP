using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class CampaignModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateStarted { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateEnded { get; set; }
    }
}
