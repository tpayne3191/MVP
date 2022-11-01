using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class CharacterRepository : ICharacterRepository
    {
        public Result<Character> Create(Character model)
        {
            throw new NotImplementedException();
        }

        public Result<List<Character>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Result<Character> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Character model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
