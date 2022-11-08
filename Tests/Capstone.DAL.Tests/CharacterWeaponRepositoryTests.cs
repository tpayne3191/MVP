using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Capstone.Core;

namespace Capstone.DAL.Tests
{
    [TestFixture]
    public class CharacterWeaponRepositoryTests
    {
        private DbConnection _connection;
        private ICharacterWeaponRepository _characterWeaponRepository;


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
            _characterWeaponRepository = new CharacterWeaponRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        [Test]
        public void CharacterWeaponCreateTestSuccess()
        {
            CharacterWeapon characterWeapon = new CharacterWeapon()
            {
                Quantity = 2,
                Weapon = new Weapon(),
                Character = new Character(),
                CharacterId = 1,
                WeaponId = 1
            };
            Result<CharacterWeapon> expectedResult = new Result<CharacterWeapon>()
            {
                Data = characterWeapon,
                Message = null,
                Success = true

            };
            expectedResult.Data.CharacterId = 1;
            expectedResult.Data.WeaponId = 1;

            var actualResult = _characterWeaponRepository.Create(characterWeapon);

            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.CharacterId, actualResult.Data.CharacterId);
            Assert.AreEqual(expectedResult.Data.WeaponId, actualResult.Data.WeaponId);
            Assert.AreEqual(expectedResult.Data.Weapon, actualResult.Data.Weapon);
            Assert.AreEqual(expectedResult.Data.Character, actualResult.Data.Character);
            Assert.AreEqual(expectedResult.Data.Quantity, actualResult.Data.Quantity);
        }
    }
}
