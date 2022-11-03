using Capstone.Core.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;

namespace Capstone.DAL.Tests
{
    [TestFixture]
    public class PlayerRepositoryTests
    {
        private DbConnection _connection;
        private IPlayerRepository _playerRepository;

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
            _playerRepository = new PlayerRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        [Test]
        public void PlayerCreateTestSuccess()
        {
            // Assign
            Player player = new Player()
            {
                Name = "Ernest",
                Email = "Ernest_C_King@Progressive.com",
                City = "Colorado Springs",
                Phone = "801-631-2160",
                Characters = new List<Character>()
            };
            Result<Player> expectedResult = new Result<Player>()
            {
                Message = null,
                Success = true,
                Data = player
            };
            expectedResult.Data.Id = 1;

            // Act
            var actualResult = _playerRepository.Create(player);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.City, actualResult.Data.City);
            Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
            Assert.AreEqual(expectedResult.Data.Phone, actualResult.Data.Phone);
            Assert.AreEqual(expectedResult.Data.Email, actualResult.Data.Email);
        }

        [Test]
        public void PlayerReadAllSuccessfully()
        {
            // Assign

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        public void PlayerReadByIdSuccessfully()
        {

            // Assign

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        public void PlayerUpdateTestSuccessfully()
        {
            // Assign

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        public void PlayerDeleteTestSuccessfully()
        {
            // Assign

            // Act

            // Assert
            Assert.Pass();
        }
    }
}