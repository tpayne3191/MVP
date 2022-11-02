using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class PlayerRepository : IPlayerRepository
    {
        private AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result<Player> Create(Player Player)
        {
            try
            {
                _context.Player.Add(Player);
                _context.SaveChanges();
                return new Result<Player>() { Success = true, Data = Player };
            }
            catch (Exception e)
            {
                return new Result<Player>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<List<Player>> ReadAll()
        {
            try
            {
                var result = _context.Player.ToList();
                return new Result<List<Player>>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<List<Player>>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<Player> ReadById(int id)
        {
            try
            {
                var result = _context.Player.FirstOrDefault(
                    i => i.Id == id);
                return new Result<Player>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<Player>() { Success = false, Data = null, Message = e.Message };

            }
        }

        public Result Update(Player Player)
        {
            try
            {
                _context.Player.Update(Player);
                _context.SaveChanges();
                return new Result<Player>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Player>() { Success = false, Message = e.Message };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                Result<Player> Player = ReadById(id);
                if (Player != null)
                {
                    _context.Player.Remove(Player.Data);
                    _context.SaveChanges();
                }

                return new Result<Player>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Player>() { Success = false, Message = e.Message };
            }
        }
    }
}
