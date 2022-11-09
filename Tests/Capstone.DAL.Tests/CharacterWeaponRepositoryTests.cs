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
                Weapon = new Weapon()
                {
                    Name = "Test",
                    Damage = 5,
                    Range = 5,
                    Description = "Fun"
                },
                Character = new Character()
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
                },
                
               
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

        [Test]

        public void CharacterWeaponReadAllTestSuccess()
        {
            // Assign
            CharacterWeapon characterWeapon = new CharacterWeapon()
            {
                Quantity = 2,
                Weapon = new Weapon()
                {
                    Name = "Test",
                    Damage = 5,
                    Range = 5,
                    Description = "Fun"
                },
                Character = new Character()
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
                },
            };
            Result<List<CharacterWeapon>> expectedResult = new Result<List<CharacterWeapon>>()
            {
                Data = new List<CharacterWeapon>() {characterWeapon},
                Message = null,
                Success = true

            };
            expectedResult.Data[0].CharacterId = 1;
            expectedResult.Data[0].WeaponId = 1;
            _characterWeaponRepository.Create(characterWeapon);

            // Act
            var actualResult = _characterWeaponRepository.ReadAll();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data[0].CharacterId, actualResult.Data[0].CharacterId);
            Assert.AreEqual(expectedResult.Data[0].WeaponId, actualResult.Data[0].WeaponId);
            Assert.AreEqual(expectedResult.Data[0].Weapon, actualResult.Data[0].Weapon);
            Assert.AreEqual(expectedResult.Data[0].Character, actualResult.Data[0].Character);
            Assert.AreEqual(expectedResult.Data[0].Quantity, actualResult.Data[0].Quantity);
        }

        [Test]

        public void CharacterWeaponByIdTest()
        {
            //Assign
            CharacterWeapon characterWeapon = new CharacterWeapon()
            {
                Quantity = 2,
                Weapon = new Weapon()
                {
                    Name = "Test",
                    Damage = 5,
                    Range = 5,
                    Description = "Fun"
                },
                Character = new Character()
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
                },
            };
            Result<CharacterWeapon> expectedResult = new Result<CharacterWeapon>()
            {
                Data =  characterWeapon,
                Message = null,
                Success = true

            };
            expectedResult.Data.CharacterId = 1;
            expectedResult.Data.WeaponId = 1;

            _characterWeaponRepository.Create(characterWeapon);

            // Act
            var actualResult = _characterWeaponRepository.ReadById(expectedResult.Data.CharacterId, expectedResult.Data.WeaponId);
            //Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.CharacterId, actualResult.Data.CharacterId);
            Assert.AreEqual(expectedResult.Data.WeaponId, actualResult.Data.WeaponId);
            Assert.AreEqual(expectedResult.Data.Weapon, actualResult.Data.Weapon);
            Assert.AreEqual(expectedResult.Data.Character, actualResult.Data.Character);
            Assert.AreEqual(expectedResult.Data.Quantity, actualResult.Data.Quantity);
        }

        [Test]
        public void CharacterWeaponUpdateTestSuccess()
        {
            //Assign
            CharacterWeapon characterWeapon = new CharacterWeapon()
            {
                Quantity = 2,
                Weapon = new Weapon()
                {
                    Name = "Test",
                    Damage = 5,
                    Range = 5,
                    Description = "Fun"
                },
                Character = new Character()
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
                },
            };
            Result<CharacterWeapon> expectedResult = new Result<CharacterWeapon>()
            {
                Data = characterWeapon,
                Message = null,
                Success = true

            };
            expectedResult.Data.CharacterId = 1;
            expectedResult.Data.WeaponId = 1;
            _characterWeaponRepository.Create(characterWeapon);

            CharacterWeapon updatedCharacterWeapon = new CharacterWeapon()
            {
                CharacterId = characterWeapon.CharacterId,
                WeaponId = characterWeapon.WeaponId,
                Quantity = characterWeapon.Quantity,
                Weapon = characterWeapon.Weapon,
                Character = characterWeapon.Character
            };

            expectedResult.Data = updatedCharacterWeapon;

            var actualResult = _characterWeaponRepository.Update(updatedCharacterWeapon);

            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);

            if (actualResult is Result<CharacterWeapon> characterWeaponResult)
            {
                Assert.AreEqual(expectedResult.Data.CharacterId, characterWeaponResult.Data.CharacterId);
                Assert.AreEqual(expectedResult.Data.WeaponId, characterWeaponResult.Data.WeaponId);
                Assert.AreEqual(expectedResult.Data.Weapon, characterWeaponResult.Data.Weapon);
                Assert.AreEqual(expectedResult.Data.Character, characterWeaponResult.Data.Character);
                Assert.AreEqual(expectedResult.Data.Quantity, characterWeaponResult.Data.Quantity);
            }
        }

        [Test]

        public void CharacterWeaponDeleteTestSuccess()
        {
            CharacterWeapon characterWeapon = new CharacterWeapon()
            {
                Quantity = 2,
                Weapon = new Weapon()
                {
                    Name = "Test",
                    Damage = 5,
                    Range = 5,
                    Description = "Fun"
                },
                Character = new Character()
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
                },
            };
            Result<CharacterWeapon> expectedResult = new Result<CharacterWeapon>()
            {
                Data = characterWeapon,
                Message = null,
                Success = true

            };
            expectedResult.Data.CharacterId = 1;
            expectedResult.Data.WeaponId = 1;
            _characterWeaponRepository.Create(characterWeapon);

            var actualResult =
                _characterWeaponRepository.Delete(expectedResult.Data.CharacterId, expectedResult.Data.CharacterId);

            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
        }
    }
}
