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
    public class CharacterRepositoryTests
    {
        private DbConnection _connection;
        private ICharacterRepository _characterRepository;

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
            _characterRepository = new CharacterRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        //[Test]
        //public void CharacterCreateTestSuccess()
        //{
        //    // Assign
        //    Character character = new Character()
        //    {
        //        Name = "Sword",
        //        DateStarted = DateTime.Parse("08/08/2021"),
        //        DateEnded = DateTime.Parse("08/10/2021"),
        //        Characters = new List<Character>()
        //    };
        //    Result<Character> expectedResult = new Result<Character>()
        //    {
        //        Data = character,
        //        Message = null,
        //        Success = true
        //    };
        //    expectedResult.Data.Id = 1;

        //    // Act
        //    var actualResult = _characterRepository.Create(character);

        //    // Assert
        //    Assert.AreEqual(expectedResult.Success, actualResult.Success);
        //    Assert.AreEqual(expectedResult.Message, actualResult.Message);
        //    Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
        //    Assert.AreEqual(expectedResult.Data.Characters, actualResult.Data.Characters);
        //    Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
        //    Assert.AreEqual(expectedResult.Data.DateStarted, actualResult.Data.DateStarted);
        //    Assert.AreEqual(expectedResult.Data.DateEnded, actualResult.Data.DateEnded);
        //}

        //[Test]
        //public void CharacterReadAllTestSuccess()
        //{
        //    // Assign
        //    Character character = new Character()
        //    {
        //        Name = "Sword",
        //        DateStarted = DateTime.Parse("08/08/2021"),
        //        DateEnded = DateTime.Parse("08/10/2021"),
        //        Characters = new List<Character>()
        //    };
        //    Result<List<Character>> expectedResult = new Result<List<Character>>()
        //    {
        //        Data = new List<Character>() { character },
        //        Message = null,
        //        Success = true
        //    };

        //    expectedResult.Data[0].Id = 1;
        //    _characterRepository.Create(character);

        //    // Act
        //    var actualResult = _characterRepository.ReadAll();

        //    // Assert
        //    Assert.AreEqual(expectedResult.Success, actualResult.Success);
        //    Assert.AreEqual(expectedResult.Message, actualResult.Message);
        //    Assert.AreEqual(expectedResult.Data[0].Id, actualResult.Data[0].Id);
        //    Assert.AreEqual(expectedResult.Data[0].Characters, actualResult.Data[0].Characters);
        //    Assert.AreEqual(expectedResult.Data[0].Name, actualResult.Data[0].Name);
        //    Assert.AreEqual(expectedResult.Data[0].DateStarted, actualResult.Data[0].DateStarted);
        //    Assert.AreEqual(expectedResult.Data[0].DateEnded, actualResult.Data[0].DateEnded);
        //}

        //[Test]
        //public void CharacterByIdTestSuccess()
        //{
        //    // Assign
        //    Character character = new Character()
        //    {
        //        Name = "Sword",
        //        DateStarted = DateTime.Parse("08/08/2021"),
        //        DateEnded = DateTime.Parse("08/10/2021"),
        //        Characters = new List<Character>()
        //    };
        //    Result<Character> expectedResult = new Result<Character>()
        //    {
        //        Data = character,
        //        Message = null,
        //        Success = true
        //    };
        //    expectedResult.Data.Id = 1;
        //    _characterRepository.Create(character);
        //    // Act
        //    var actualResult = _characterRepository.ReadById(expectedResult.Data.Id);

        //    // Assert
        //    Assert.AreEqual(expectedResult.Success, actualResult.Success);
        //    Assert.AreEqual(expectedResult.Message, actualResult.Message);
        //    Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
        //    Assert.AreEqual(expectedResult.Data.Characters, actualResult.Data.Characters);
        //    Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
        //    Assert.AreEqual(expectedResult.Data.DateStarted, actualResult.Data.DateStarted);
        //    Assert.AreEqual(expectedResult.Data.DateEnded, actualResult.Data.DateEnded);


        //}

        //[Test]
        //public void CharacterUpdateTestSuccess()
        //{
        //    // Assign


        //    // Act

        //    // Assert
        //    Assert.Pass();
        //}

        [Test]
        public void CharacterDeleteTestSuccess()
        {
            Character character = new Character()
            {
               Name = "The One",
               Level = 6,
               ArmorClass = 35,
               HitPoints = 350,
               Race = "Elf",
               Alignment = "red",
               Class = "High ",
               Image = "img",
               Strength = 15,
               Dexterity = 10,
               Constitution = 17,
               Intelligence = 12,
               Wisdom = 11,
               Charisma = 10,
               CharacterWeapons = new List<CharacterWeapon>(),
               Player = new Player()
               {
                   Name = "John Smith",
                   City = "SLC",
                   Email = "None@None.com",
                   Phone = "123-456-7890"
               },
               Campaign = new Campaign()
               {
                   Name = "Test Name",
                   DateStarted = DateTime.MinValue,
                   DateEnded = DateTime.MaxValue,
               }
            };
            Result<Character> expectedResult = new Result<Character>()
            {
                Data = character,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            expectedResult.Data.CampaignId = 1;
            expectedResult.Data.PlayerId = 1;

            _characterRepository.Create(character);
            // Act
            var actualResult = _characterRepository.Delete(expectedResult.Data.Id);
            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
        }
    }
}
