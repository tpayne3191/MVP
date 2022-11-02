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

        public Result<Character> Create(Character character)
        {
            try
            {
                _context.Character.Add(character);
                _context.SaveChanges();
                return new Result<Character>() { Success = true, Data = character };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
            }
        }

        public Result Delete(int id)
        {
            try
            {
                Result<Character> character = ReadById(id);
                if (character != null)
                {
                    _context.Character.Remove(character.Data);
                    _context.SaveChanges();
                }

                return new Result<Character>() { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

