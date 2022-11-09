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

        [Test]
        public void CharacterCreateTestSuccess()
        {
            // Assign
            Character character = new Character()
            {
                Name = "Test",
                Level = 4,
                Alignment = "Test",
                ArmorClass = 15,
                Race = "Test",
                Class = "Test",
                Strength = 5,
                Dexterity = 6,
                HitPoints = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
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
                },
            
            };
            Result<Character> expectedResult = new Result<Character>()
            {
                Data = character,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;

            // Act
            var actualResult = _characterRepository.Create(character);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.Level, actualResult.Data.Level);
            Assert.AreEqual(expectedResult.Data.Alignment, actualResult.Data.Alignment);
            Assert.AreEqual(expectedResult.Data.ArmorClass, actualResult.Data.ArmorClass);
            Assert.AreEqual(expectedResult.Data.Class, actualResult.Data.Class);
            Assert.AreEqual(expectedResult.Data.Strength, actualResult.Data.Strength);
            Assert.AreEqual(expectedResult.Data.Dexterity, actualResult.Data.Dexterity);
            Assert.AreEqual(expectedResult.Data.HitPoints, actualResult.Data.HitPoints);
            Assert.AreEqual(expectedResult.Data.Constitution, actualResult.Data.Constitution);
            Assert.AreEqual(expectedResult.Data.Intelligence, actualResult.Data.Intelligence);
            Assert.AreEqual(expectedResult.Data.Wisdom, actualResult.Data.Wisdom);
            Assert.AreEqual(expectedResult.Data.Charisma, actualResult.Data.Charisma);
            Assert.AreEqual(expectedResult.Data.CharacterWeapons, actualResult.Data.CharacterWeapons);
            Assert.AreEqual(expectedResult.Data.Player, actualResult.Data.Player);
            Assert.AreEqual(expectedResult.Data.Campaign, actualResult.Data.Campaign);

        }

        [Test]
        public void CharacterReadAllTestSuccess()
        {
            // Assign
            Character character = new Character()
            {
                Name = "Test",
                Level = 4,
                Alignment = "Test",
                ArmorClass = 15,
                Race = "Test",
                Class = "Test",
                Strength = 5,
                Dexterity = 6,
                HitPoints = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
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
                },

            };
            Result<List<Character>> expectedResult = new Result<List<Character>>()
            {
                Data = new List<Character>() { character },
                Message = null,
                Success = true
            };

            expectedResult.Data[0].Id = 1;
            _characterRepository.Create(character);

            // Act
            var actualResult = _characterRepository.ReadAll();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data[0].Id, actualResult.Data[0].Id);
            Assert.AreEqual(expectedResult.Data[0].Level, actualResult.Data[0].Level);
            Assert.AreEqual(expectedResult.Data[0].Alignment, actualResult.Data[0].Alignment);
            Assert.AreEqual(expectedResult.Data[0].ArmorClass, actualResult.Data[0].ArmorClass);
            Assert.AreEqual(expectedResult.Data[0].Class, actualResult.Data[0].Class);
            Assert.AreEqual(expectedResult.Data[0].Strength, actualResult.Data[0].Strength);
            Assert.AreEqual(expectedResult.Data[0].Dexterity, actualResult.Data[0].Dexterity);
            Assert.AreEqual(expectedResult.Data[0].HitPoints, actualResult.Data[0].HitPoints);
            Assert.AreEqual(expectedResult.Data[0].Constitution, actualResult.Data[0].Constitution);
            Assert.AreEqual(expectedResult.Data[0].Intelligence, actualResult.Data[0].Intelligence);
            Assert.AreEqual(expectedResult.Data[0].Wisdom, actualResult.Data[0].Wisdom);
            Assert.AreEqual(expectedResult.Data[0].Charisma, actualResult.Data[0].Charisma);
            Assert.AreEqual(expectedResult.Data[0].CharacterWeapons, actualResult.Data[0].CharacterWeapons);
            Assert.AreEqual(expectedResult.Data[0].Player, actualResult.Data[0].Player);
            Assert.AreEqual(expectedResult.Data[0].Campaign, actualResult.Data[0].Campaign);
        }

        [Test]
        public void CharacterByIdTestSuccess()
        {
            // Assign
            Character character = new Character()
            {
                Name = "Test",
                Level = 4,
                Alignment = "Test",
                ArmorClass = 15,
                Race = "Test",
                Class = "Test",
                Strength = 5,
                Dexterity = 6,
                HitPoints = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
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
                },

            };
            Result<Character> expectedResult = new Result<Character>()
            {
                Data = character,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _characterRepository.Create(character);
            // Act
            var actualResult = _characterRepository.ReadById(expectedResult.Data.Id);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.Level, actualResult.Data.Level);
            Assert.AreEqual(expectedResult.Data.Alignment, actualResult.Data.Alignment);
            Assert.AreEqual(expectedResult.Data.ArmorClass, actualResult.Data.ArmorClass);
            Assert.AreEqual(expectedResult.Data.Class, actualResult.Data.Class);
            Assert.AreEqual(expectedResult.Data.Strength, actualResult.Data.Strength);
            Assert.AreEqual(expectedResult.Data.Dexterity, actualResult.Data.Dexterity);
            Assert.AreEqual(expectedResult.Data.HitPoints, actualResult.Data.HitPoints);
            Assert.AreEqual(expectedResult.Data.Constitution, actualResult.Data.Constitution);
            Assert.AreEqual(expectedResult.Data.Intelligence, actualResult.Data.Intelligence);
            Assert.AreEqual(expectedResult.Data.Wisdom, actualResult.Data.Wisdom);
            Assert.AreEqual(expectedResult.Data.Charisma, actualResult.Data.Charisma);
            Assert.AreEqual(expectedResult.Data.CharacterWeapons, actualResult.Data.CharacterWeapons);
            Assert.AreEqual(expectedResult.Data.Player, actualResult.Data.Player);
            Assert.AreEqual(expectedResult.Data.Campaign, actualResult.Data.Campaign);


        }

        [Test]
        public void CharacterUpdateTestSuccess()
        {
            // Assign
            Character character = new Character()
            {
                Name = "Test",
                Level = 4,
                Alignment = "Test",
                ArmorClass = 15,
                Race = "Test",
                Class = "Test",
                Strength = 5,
                Dexterity = 6,
                HitPoints = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
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
                },

            };
            Result<Character> expectedResult = new Result<Character>()
            {
                Data = character,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _characterRepository.Create(character);

            Character updatedCharacter = new Character()
            {
                Id = character.Id,
                Name = character.Name,
                Level = character.Level,
                Alignment = character.Alignment,
                ArmorClass = character.ArmorClass,
                Race = character.Race,
                Class = character.Class,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                HitPoints = character.HitPoints,
                Constitution = character.Constitution,
                Intelligence = character.Intelligence,
                Charisma = character.Charisma,
                CharacterWeapons = character.CharacterWeapons,
                PlayerId = character.PlayerId,
                Player = character.Player,
                CampaignId = character.CampaignId,
                Campaign = character.Campaign,
            };
            expectedResult.Data = updatedCharacter;

            var actualResult = _characterRepository.Update(updatedCharacter);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            if (actualResult is Result<Character> characterResult)
            {
                Assert.AreEqual(expectedResult.Success, actualResult.Success);
                Assert.AreEqual(expectedResult.Message, actualResult.Message);
                Assert.AreEqual(expectedResult.Data.Id, characterResult.Data.Id);
                Assert.AreEqual(expectedResult.Data.Level, characterResult.Data.Level);
                Assert.AreEqual(expectedResult.Data.Alignment, characterResult.Data.Alignment);
                Assert.AreEqual(expectedResult.Data.ArmorClass, characterResult.Data.ArmorClass);
                Assert.AreEqual(expectedResult.Data.Class, characterResult.Data.Class);
                Assert.AreEqual(expectedResult.Data.Strength, characterResult.Data.Strength);
                Assert.AreEqual(expectedResult.Data.Dexterity, characterResult.Data.Dexterity);
                Assert.AreEqual(expectedResult.Data.HitPoints, characterResult.Data.HitPoints);
                Assert.AreEqual(expectedResult.Data.Constitution, characterResult.Data.Constitution);
                Assert.AreEqual(expectedResult.Data.Intelligence, characterResult.Data.Intelligence);
                Assert.AreEqual(expectedResult.Data.Wisdom, characterResult.Data.Wisdom);
                Assert.AreEqual(expectedResult.Data.Charisma, characterResult.Data.Charisma);
                Assert.AreEqual(expectedResult.Data.CharacterWeapons, characterResult.Data.CharacterWeapons);
                Assert.AreEqual(expectedResult.Data.Player, characterResult.Data.Player);
                Assert.AreEqual(expectedResult.Data.Campaign, characterResult.Data.Campaign);

            }
        }

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
