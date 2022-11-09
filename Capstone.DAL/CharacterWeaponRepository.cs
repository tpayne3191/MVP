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

        public CharacterWeaponRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result<CharacterWeapon> Create(CharacterWeapon model)
        {
            try
            {
                _context.CharacterWeapon.Add(model);
                _context.SaveChanges();
                return new Result<CharacterWeapon>() { Success = true, Data = model };
            }
            catch (Exception e)
            {
                return new Result<CharacterWeapon>() { Success = false, Data = null, Message = e.Message };
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
                return new Result<Campaign>() { Success = false, Message = e.Message };
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
                return new Result<List<CharacterWeapon>>() { Success = false, Data = null, Message = e.Message };

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
                return new Result<CharacterWeapon>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result Update(CharacterWeapon model)
        {
            var characterWeaponResult = ReadById(model.CharacterId, model.WeaponId);
            try
            {
                if (characterWeaponResult.Success)
                {
                    _context.Entry(characterWeaponResult.Data).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                }
                return new Result<CharacterWeapon>() { Success = true, Data = model };

            }
            catch (Exception e)
            {
                return new Result<CharacterWeapon>() { Success = false, Message = e.Message };
            }
        }
    }
}