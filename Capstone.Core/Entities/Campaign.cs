using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateStarted { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateEnded { get; set; }
    }
}
