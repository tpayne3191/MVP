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

        public Result<List<LongestCampaigns>> GetLongestCampaigns()
        {
            var longestCampaigns = new List<LongestCampaigns>();
            using (var cn = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("LongestCampaigns", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                var reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        LongestCampaigns model = new LongestCampaigns
                        {
                            DateDiff = (int)reader["DateDiff"],
                            Name = reader["Name"].ToString(),
                            DateStarted = (DateTime)reader["DateStarted"],
                            DateEnded = (DateTime)reader["DateEnded"],
                        };
                        longestCampaigns.Add(model);
                    }
                }
                catch (Exception e)
                {
                    return new Result<List<LongestCampaigns>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<LongestCampaigns>>() { Success = true, Data = longestCampaigns };
        }

        public Result<List<LargestHealthPools>> GetCharactersByHealthPool()
        {
            var characters = new List<LargestHealthPools>();
            using (var cn = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("LargestHealthPools", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                var reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        LargestHealthPools model = new LargestHealthPools
                        {
                            Id = (int)reader["Id"],
                            HitPoints = (int)reader["HitPoints"],
                            ArmorClass = (int)reader["ArmorClass"],
                            Name = reader["Name"].ToString(),
                            Class = reader["Class"].ToString(),
                            Alignment = reader["Alignment"].ToString()
                        };
                        characters.Add(model);
                    }

                }
                catch (Exception e)
                {
                    return new Result<List<LargestHealthPools>>() { Success = false, Data = null, Message = e.Message};
                }
            }

            return new Result<List<LargestHealthPools>>() { Success = true, Data = characters };
        }
    }
}
