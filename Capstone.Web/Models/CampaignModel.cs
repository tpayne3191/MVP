using System;

namespace Capstone.Web.Models
{
    public class CampaignModel
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
    }
}
