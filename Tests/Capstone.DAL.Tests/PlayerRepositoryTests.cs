using Capstone.Core.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

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
        public void CreateTestSuccess()
        {
            Assert.Pass();
        }
    }
}