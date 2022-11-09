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
        public Result Delete(string loginItemUserId);
        public Result<LoginItem> Get(string loginItemUserId);
        public bool ValidateUserName(string userId, string password, int playerId);
    }
}
