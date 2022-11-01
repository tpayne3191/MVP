using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;

namespace Capstone.DAL
{
    public class WeaponRepository : IWeaponRepository
    {
        public Result<Weapon> Create(Weapon model)
        {
            throw new NotImplementedException();
        }

        public Result<List<Weapon>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Result<Weapon> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Weapon model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
