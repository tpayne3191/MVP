using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

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
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
            }
        }

        public Result<Weapon> ReadById(int id)
        {
            try
            {
                var result = _context.Weapon.FirstOrDefault(
                    i => i.id == id);
                return new Result<Weapon>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result Update(Weapon Weapon)
        {
            try
            {
                _context.Weapon.Update(Weapon);
                _context.SaveChanges();
                return new Result<Weapon>() { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result Delete(int id)
        {
            try
            {
                Result<Weapon> Weapon = ReadById(id);
                if (Weapon != null)
                {
                    _context.Weapon.Remove(Weapon.Data);
                    _context.SaveChanges();
                }

                return new Result<Weapon>() { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
