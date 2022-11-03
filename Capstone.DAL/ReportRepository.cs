using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Capstone.Core;
using Capstone.Core.DTOs;
using Capstone.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Capstone.DAL
{
    public class ReportRepository : IReportRepository
    {

        public Result<List<LongestCampaigns>> GetTopCampaigns()
        {
            List<LongestCampaigns> campaignsCompleted = new List<LongestCampaigns>();
            using (var cn = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("MostCampaignsCompleted", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                var reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        LongestCampaigns campaignCompleted = new LongestCampaigns();
                        campaignCompleted.CompletedCampaignCount = (int)reader["CampaignsCompleted"];
                        campaignCompleted.Name = reader["Name"].ToString();
                        campaignsCompleted.Add(campaignCompleted);
                    }
                }
                catch (Exception e)
                {
                    return new Result<List<LongestCampaigns>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<LongestCampaigns>>() { Success = true, Data = campaignsCompleted };
        }

        public Result<List<LargestHealthPools>> GetTopHitPointCharacters()
        {
            List<LargestHealthPools> hitPoints = new List<LargestHealthPools>();
            using (var cn = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("MostHitPoints", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                var reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        LargestHealthPools hitPoint = new LargestHealthPools();
                        hitPoint.AmountOfHitPoints = (int)reader["HitPoints"];
                        hitPoint.Name = reader["Name"].ToString();
                        hitPoints.Add(hitPoint);
                    }

                }
                catch (Exception e)
                {
                    return new Result<List<LargestHealthPools>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<LargestHealthPools>>() { Success = true, Data = hitPoints };
        }
    }
}
