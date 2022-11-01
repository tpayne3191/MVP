using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class CampaignRepository : ICampaignRepository
    {
        public Result<Campaign> Create(Campaign model)
        {
            throw new NotImplementedException();
        }

        public Result<List<Campaign>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Result<Campaign> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Campaign model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
