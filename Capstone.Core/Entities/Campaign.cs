using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        
        public string Name { get; set; }

        public DateTime DateStarted { get; set; }
        
        public DateTime DateEnded { get; set; }


    }
}
