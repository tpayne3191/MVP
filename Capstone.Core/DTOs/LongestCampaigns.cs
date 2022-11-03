using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.DTOs
{
    public class LongestCampaigns
    {
        public int Id { get; set; }
        public int DateDiff { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
    }
}
