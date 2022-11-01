using System;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.DAL
{
    public class CharacterWeaponRepository : ICharacterWeaponRepository
    {
        private AppDbContext _context;

        public Result Create(CharacterWeapon model)
        {
            try
            {
                _context.CharacterWeapon.Add(model);
                _context.SaveChanges();
                return new Result<CharacterWeapon>() { Success = true, Data = model };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result Delete(int characterId, int weaponId)
        {
            try
            {
                Result<CharacterWeapon> characterWeapon = ReadById(characterId, weaponId);
                if (characterWeapon != null)
                {
                    _context.CharacterWeapon.Remove(characterWeapon.Data);
                    _context.SaveChanges();
                }

                return new Result<Campaign>() { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result<List<CharacterWeapon>> ReadAll()
        {
            try
            {
                var result = _context.CharacterWeapon.ToList();
                return new Result<List<CharacterWeapon>>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result<CharacterWeapon> ReadById( int characterId, int weaponId )
        {
            try
            {
                var result = _context.CharacterWeapon.FirstOrDefault(
                    i => i.CharacterId == characterId && i.WeaponId == weaponId);
                return new Result<CharacterWeapon>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result Update(CharacterWeapon model)
        {
            try
            {
                _context.CharacterWeapon.Update(model);
                _context.SaveChanges();
                return new Result<CharacterWeapon>() { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}