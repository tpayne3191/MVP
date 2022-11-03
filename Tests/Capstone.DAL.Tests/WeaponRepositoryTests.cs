using NUnit.Framework;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Capstone.DAL.Tests
{
    [TestFixture]
    public class WeaponRepositoryTests
    {
        private DbConnection _connection;
        private IWeaponRepository _weaponRepository;

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
            _weaponRepository = new WeaponRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        [Test]
        public void WeaponCreateTestSuccess()
        {
            // Assign
            Weapon weapon = new Weapon()
            {
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10005000,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            Result<Weapon> expectedResult = new Result<Weapon>()
            {
                Data = weapon,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;

            // Act
            var actualResult = _weaponRepository.Create(weapon);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.AreEqual(expectedResult.Data.CharacterWeapons, actualResult.Data.CharacterWeapons);
            Assert.AreEqual(expectedResult.Data.Damage, actualResult.Data.Damage);
            Assert.AreEqual(expectedResult.Data.Description, actualResult.Data.Description);
            Assert.AreEqual(expectedResult.Data.Name, actualResult.Data.Name);
            Assert.AreEqual(expectedResult.Data.Range, actualResult.Data.Range);
        }

        [Test]
        public void WeaponReadAllTestSuccess()
        {
            // Assign
            Weapon weapon = new Weapon()
            {
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10005000,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            Result<List<Weapon>> expectedResult = new Result<List<Weapon>>
            {
                Data = new List<Weapon>() { weapon },
                Message = null,
                Success = true
            };
            expectedResult.Data[0].Id = 1;
            _weaponRepository.Create(weapon);

            // Act
            var actualResult = _weaponRepository.ReadAll();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            Assert.AreEqual(expectedResult.Data[0].Id, actualResult.Data[0].Id);
            Assert.AreEqual(expectedResult.Data[0].CharacterWeapons, actualResult.Data[0].CharacterWeapons);
            Assert.AreEqual(expectedResult.Data[0].Damage, actualResult.Data[0].Damage);
            Assert.AreEqual(expectedResult.Data[0].Description, actualResult.Data[0].Description);
            Assert.AreEqual(expectedResult.Data[0].Name, actualResult.Data[0].Name);
            Assert.AreEqual(expectedResult.Data[0].Range, actualResult.Data[0].Range);
        }

        [Test]
        public void WeaponReadByIdTestSuccess()
        {
            // Assign
            Weapon weapon = new Weapon()
            {
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10005000,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            Result<Weapon> expectedResult = new Result<Weapon>
            {
                Data = weapon,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;
            _weaponRepository.Create(weapon);

            // Act
            var actualResult = _weaponRepository.ReadById(weapon.Id);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            if (actualResult is Result<Weapon> weaponResult)
            {
                Assert.AreEqual(expectedResult.Data.Id, weaponResult.Data.Id);
                Assert.AreEqual(expectedResult.Data.CharacterWeapons, weaponResult.Data.CharacterWeapons);
                Assert.AreEqual(expectedResult.Data.Damage, weaponResult.Data.Damage);
                Assert.AreEqual(expectedResult.Data.Description, weaponResult.Data.Description);
                Assert.AreEqual(expectedResult.Data.Name, weaponResult.Data.Name);
                Assert.AreEqual(expectedResult.Data.Range, weaponResult.Data.Range);
            }
        }

        [Test]
        public void WeaponUpdateTestSuccess()
        {
            // Assign
            Weapon weapon = new Weapon()
            {
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10005000,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            _weaponRepository.Create(weapon);
            Weapon updatedWeapon = new Weapon()
            {
                Id = 1,
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            Result<Weapon> expectedResult = new Result<Weapon>
            {
                Data = updatedWeapon,
                Message = null,
                Success = true
            };

            // Act
            var actualResult = _weaponRepository.Update(updatedWeapon);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
            if (actualResult is Result<Weapon> weaponResult)
            {
                Assert.AreEqual(expectedResult.Data.Id, weaponResult.Data.Id);
                Assert.AreEqual(expectedResult.Data.CharacterWeapons, weaponResult.Data.CharacterWeapons);
                Assert.AreEqual(expectedResult.Data.Damage, weaponResult.Data.Damage);
                Assert.AreEqual(expectedResult.Data.Description, weaponResult.Data.Description);
                Assert.AreEqual(expectedResult.Data.Name, weaponResult.Data.Name);
                Assert.AreEqual(expectedResult.Data.Range, weaponResult.Data.Range);
            }
        }

        [Test]
        public void WeaponDeleteTestSuccess()
        {
            // Assign
            Weapon weapon = new Weapon()
            {
                Name = "Sword",
                Description = "Excalibur",
                Damage = 10005000,
                Range = 800,
                CharacterWeapons = new List<CharacterWeapon>()
            };
            _weaponRepository.Create(weapon);
            Result<Weapon> expectedResult = new Result<Weapon>
            {
                Data = weapon,
                Message = null,
                Success = true
            };
            expectedResult.Data.Id = 1;

            // Act
            var actualResult = _weaponRepository.Delete(expectedResult.Data.Id);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Message, actualResult.Message);
        }
    }
}
