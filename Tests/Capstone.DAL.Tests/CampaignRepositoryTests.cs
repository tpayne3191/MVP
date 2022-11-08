using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Capstone.DAL.Tests
{
    [TestFixture]
    public class CampaignRepositoryTests
    {
        private DbConnection _connection;
        private ICampaignRepository _campaignRepository;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;

            AppDbContext dbContext = new AppDbContext(options);
            if (dbContext.Database.EnsureCreated()) ;
            _campaignRepository = new CampaignRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        [Test]
        public void CampaignCreateTestSuccess()
        {
            // Assign
            Campaign campaign = new Campaign()
            {
                Name = "Sword",
                DateStarted = DateTime.Parse("08/08/2021"),
                DateEnded = DateTime.Parse("08/10/2021"),
                Characters = new List<Character>()
            };
            Result<Campaign> expectedResult = new Result<Campaign>()
            {
                Data = campaign,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;

            // Act
            var actualResult = _campaignRepository.Create(campaign);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.Characters, actualResult.Data.Characters);
            Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
            Assert.AreEqual(expectedResult.Data.DateStarted, actualResult.Data.DateStarted);
            Assert.AreEqual(expectedResult.Data.DateEnded, actualResult.Data.DateEnded);
        }

        [Test]
        public void CampaignReadAllTestSuccess()
        {
            // Assign
            Campaign campaign = new Campaign()
            {
                Name = "Sword",
                DateStarted = DateTime.Parse("08/08/2021"),
                DateEnded = DateTime.Parse("08/10/2021"),
                Characters = new List<Character>()
            };
            Result<List<Campaign>> expectedResult = new Result<List<Campaign>>()
            {
                Data = new List<Campaign>() { campaign },
                Message = null,
                Success = true
            };

            expectedResult.Data[0].Id = 1;
            _campaignRepository.Create(campaign);

            // Act
            var actualResult = _campaignRepository.ReadAll();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data[0].Id, actualResult.Data[0].Id);
            Assert.AreEqual(expectedResult.Data[0].Characters, actualResult.Data[0].Characters);
            Assert.AreEqual(expectedResult.Data[0].Name, actualResult.Data[0].Name);
            Assert.AreEqual(expectedResult.Data[0].DateStarted, actualResult.Data[0].DateStarted);
            Assert.AreEqual(expectedResult.Data[0].DateEnded, actualResult.Data[0].DateEnded);
        }

        [Test]
        public void CampaignByIdTestSuccess()
        {
            // Assign
            Campaign campaign = new Campaign()
            {
                Name = "Sword",
                DateStarted = DateTime.Parse("08/08/2021"),
                DateEnded = DateTime.Parse("08/10/2021"),
                Characters = new List<Character>()
            };
            Result<Campaign> expectedResult = new Result<Campaign>()
            {
                Data = campaign,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _campaignRepository.Create(campaign);
            // Act
            var actualResult = _campaignRepository.ReadById(expectedResult.Data.Id);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.Characters, actualResult.Data.Characters);
            Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
            Assert.AreEqual(expectedResult.Data.DateStarted, actualResult.Data.DateStarted);
            Assert.AreEqual(expectedResult.Data.DateEnded, actualResult.Data.DateEnded);


        }

        [Test]
        public void CampaignUpdateTestSuccess()
        {
            // Assign
            Campaign campaign = new Campaign()
            {
                Name = "Sword",
                DateStarted = DateTime.Parse("08/08/2021"),
                DateEnded = DateTime.Parse("08/10/2021"),
                Characters = new List<Character>()
            };

            // Act
            Result<Campaign> expectedResult = new Result<Campaign>()
            {
                Data = campaign,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _campaignRepository.Create(campaign);

            Campaign updatedCampaign = new Campaign()
            {
                Id = campaign.Id,
                Name = campaign.Name,
                DateStarted = campaign.DateStarted,
                DateEnded = campaign.DateEnded,
            };
            expectedResult.Data = updatedCampaign;

            var actualResult = _campaignRepository.Update(updatedCampaign);
            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            if (actualResult is Result<Campaign> campaignResult)
            {
                Assert.AreEqual(expectedResult.Data.Id, campaignResult.Data.Id);
                Assert.AreEqual(expectedResult.Data.Name, campaignResult.Data.Name);
                Assert.AreEqual(expectedResult.Data.DateStarted, campaignResult.Data.DateStarted);
                Assert.AreEqual(expectedResult.Data.DateEnded, campaignResult.Data.DateEnded);

            }
        }

        [Test]
        public void CampaignDeleteTestSuccess()
        {
            Campaign campaign = new Campaign()
            {
                Name = "Sword",
                DateStarted = DateTime.Parse("08/08/2021"),
                DateEnded = DateTime.Parse("08/10/2021"),
                Characters = new List<Character>()
            };
            Result<Campaign> expectedResult = new Result<Campaign>()
            {
                Data = campaign,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _campaignRepository.Create(campaign);
            // Act
            var actualResult = _campaignRepository.Delete(expectedResult.Data.Id);
            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);


        }
    }
}
