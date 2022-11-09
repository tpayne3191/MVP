using Capstone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Result<LoginItem> Create(LoginItem loginItem);
        public Result<LoginItem> Update(LoginItem loginItem);
        public Result Delete(Guid loginItemUserId);
        public Result<LoginItem> Get(Guid loginItemUserId);
        public Result<List<LoginItem>> GetAll();
        public bool ValidateUserName(Guid userId, string password, int playerId);
    }
}
