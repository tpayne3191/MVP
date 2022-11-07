using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Capstone.DAL
{
    public class WeaponRepository : IWeaponRepository
    {
        private AppDbContext _context;

        public WeaponRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result<Weapon> Create(Weapon Weapon)
        {
            try
            {
                _context.Weapon.Add(Weapon);
                _context.SaveChanges();
                return new Result<Weapon>() { Success = true, Data = Weapon };
            }
            catch (Exception e) 
            {
                return new Result<Weapon>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<List<Weapon>> ReadAll()
        {
            try
            {
                var result = _context.Weapon.ToList();
                return new Result<List<Weapon>>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<List<Weapon>>() { Success = false, Data = null, Message = e.Message };

            }
        }

        public Result<Weapon> ReadById(int id)
        {
            try
            {
                var result = _context.Weapon.FirstOrDefault(
                    i => i.Id == id);
                return new Result<Weapon>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<Weapon>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result Update(Weapon weapon)
        {
            var weaponResult = ReadById(weapon.Id);
            
            try
            {
                if (weaponResult.Success)
                {
                    _context.Entry(weaponResult.Data).CurrentValues.SetValues(weapon);
                    _context.SaveChanges();
                }
                return new Result<Weapon>() { Success = true, Data = weapon };
            }
            catch (Exception e)
            {
                return new Result<Weapon>() { Success = false, Message = e.Message };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                Result<Weapon> Weapon = ReadById(id);
                if (Weapon != null)
                {
                    var weaponWithChildren = _context.Weapon
                        .Include(w => w.CharacterWeapons).Where(w => w.Id == id).FirstOrDefault();
                    _context.Weapon.Remove(weaponWithChildren);
                    _context.SaveChanges();
                }

                return new Result<Weapon>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Weapon>() { Success = false, Message = e.Message };

            }
        }
    }
}
