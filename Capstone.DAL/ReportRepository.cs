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

        public Result<List<MostCampaignsCompleted>> GetTopCampaigns()
        {
            List<MostCampaignsCompleted> campaignsCompleted = new List<MostCampaignsCompleted>();
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
                        MostCampaignsCompleted campaignCompleted = new MostCampaignsCompleted();
                        campaignCompleted.CompletedCampaignCount = (int)reader["CampaignsCompleted"];
                        campaignCompleted.Name = reader["Name"].ToString();
                        campaignsCompleted.Add(campaignCompleted);
                    }
                }
                catch (Exception e)
                {
                    return new Result<List<MostCampaignsCompleted>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<MostCampaignsCompleted>>() { Success = true, Data = campaignsCompleted };
        }

        public Result<List<MostHitPoints>> GetTopHitPointCharacters()
        {
            List<MostHitPoints> hitPoints = new List<MostHitPoints>();
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
                        MostHitPoints hitPoint = new MostHitPoints();
                        hitPoint.AmountOfHitPoints = (int)reader["HitPoints"];
                        hitPoint.Name = reader["Name"].ToString();
                        hitPoints.Add(hitPoint);
                    }

                }
                catch (Exception e)
                {
                    return new Result<List<MostHitPoints>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<MostHitPoints>>() { Success = true, Data = hitPoints };
        }
    }
}
