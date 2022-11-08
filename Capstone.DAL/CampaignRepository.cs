using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Capstone.DAL
{
    public class CampaignRepository : ICampaignRepository
    {
        private AppDbContext _context;

        public CampaignRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result<Campaign> Create(Campaign campaign)
        {
            try
            {
                _context.Campaign.Add(campaign);
                _context.SaveChanges();
                return new Result<Campaign>() { Success = true, Data = campaign };
            }
            catch (Exception e)
            {
                return new Result<Campaign>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<List<Campaign>> ReadAll()
        {
            try
            {
                var result = _context.Campaign.Include(c => c.Characters).ToList();
                return new Result<List<Campaign>>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<List<Campaign>>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<Campaign> ReadById(int id)
        {
            try
            {
                var result = _context.Campaign.Include(c => c.Characters).FirstOrDefault(
                    i => i.Id == id);
                return new Result<Campaign>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<Campaign>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result Update(Campaign campaign)
        {
            var campaignResult = ReadById(campaign.Id);

            try
            {
                if (campaignResult.Success)
                {
                    _context.Entry(campaignResult.Data).CurrentValues.SetValues(campaign);
                    _context.SaveChanges();
                }
                return new Result<Campaign>() { Success = true, Data = campaign };
            }
            catch (Exception e)
            {
                return new Result<Campaign>() { Success = false, Message = e.Message };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                 Result<Campaign> campaign = ReadById(id);
                if (campaign != null)
                {
                    _context.Campaign.Remove(campaign.Data);
                    _context.SaveChanges();
                }

                return new Result<Campaign>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Campaign>() { Success = false, Message = e.Message };
            }
        }
    }
}
