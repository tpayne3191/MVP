using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Capstone.DAL
{
    public class ConfigurationManager
    {
        private static string _authConnectionString;

        public static AppDbContext GetDbContext()
        {
            var builder = new ConfigurationBuilder();

            builder.AddUserSecrets<ConfigurationManager>();

            var config = builder.Build();

            // Update DB name if name changes in production
            var connectionString = config["ConnectionStrings:CampaignManager_DB"];

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new AppDbContext(options);
        }

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();

            builder.AddUserSecrets<ConfigurationManager>();

            var config = builder.Build();

            // Update DB name if name changes in production
            var connectionString = config["ConnectionStrings:CampaignManager_DB"];

            return connectionString;
        }

        public static string GetAuthConnectionstring()
        {
            if (string.IsNullOrEmpty(_authConnectionString))
            {
                var builder = new ConfigurationBuilder();

                builder.AddUserSecrets<AppDbContext>();

                var config = builder.Build();

                _authConnectionString = config["AuthConnectionString:CampaignManagerLoginDB"];
            }

            return _authConnectionString;
        }
    }
}
