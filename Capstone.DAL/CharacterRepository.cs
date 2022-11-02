﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class CharacterRepository : ICharacterRepository
    {
        private AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result<Character> Create(Character Character)
        {
            try
            {
                _context.Character.Add(Character);
                _context.SaveChanges();
                return new Result<Character>() { Success = true, Data = Character };
            }
            catch (Exception e)
            {
                return new Result<Character>() { Success = false, Data = null, Message = e.Message};
            }
        }

        public Result<List<Character>> ReadAll()
        {
            try
            {
                var result = _context.Character.ToList();
                return new Result<List<Character>>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<List<Character>>() { Success = false, Data = null, Message = e.Message };
            }
        }

        public Result<Character> ReadById(int id)
        {
            try
            {
                var result = _context.Character.FirstOrDefault(
                    i => i.Id == id);
                return new Result<Character>() { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new Result<Character>() { Success = false , Data = null, Message = e.Message };

            }
        }

        public Result Update(Character character)
        {
            try
            {
                _context.Character.Update(character);
                _context.SaveChanges();
                return new Result<Character>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Character>() { Success = false, Message = e.Message };

            }
        }

        public Result Delete(int id)
        {
            try
            {
                Result<Character> Character = ReadById(id);
                if (Character != null)
                {
                    _context.Character.Remove(Character.Data);
                    _context.SaveChanges();
                }

                return new Result<Character>() { Success = true };
            }
            catch (Exception e)
            {
                return new Result<Character>() { Success = false, Message = e.Message };

            }
        }
    }
}

