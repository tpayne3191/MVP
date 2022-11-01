using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class PlayerRepository : IPlayerRepository
    {
        public Result<Player> Create(Player model)
        {
            throw new NotImplementedException();
        }

        public Result<List<Player>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Result<Player> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Player model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
