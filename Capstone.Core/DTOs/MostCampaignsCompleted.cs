using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.DTOs
{
    public class MostCampaignsCompleted
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int CompletedCampaignCount { get; set; }

    }
}
