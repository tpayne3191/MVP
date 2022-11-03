using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core.DTOs;
using Capstone.Core.Entities;

namespace Capstone.Core.Interfaces
{
    
    public interface IReportRepository
    {
        Result<List<LongestCampaigns>> GetLongestCampaigns();
        Result<List<LargestHealthPools>> GetCharactersByHealthPool();
    }
}
