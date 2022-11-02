using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Capstone.Core;
using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Capstone.DAL
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Result<LoginItem> Create(LoginItem loginItem)
        {
            throw new NotImplementedException();
        }

        public Result Delete(string loginItemId)
        {
            throw new NotImplementedException();
        }

        public Result<LoginItem> Get(string loginItemUserId)
        {
            var Result = new Result<LoginItem>();

            try
            {
                using (var context = new AppDbContext())
                {
                    var item = context.LoginItem.Find(loginItemUserId);

                    if (item != null)
                    {
                        Result.Data = item;
                        Result.Success = true;
                    }
                    else
                    {
                        Result.Success = false;
                        Result.Message = $"Entity with id {loginItemUserId} not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }

            return Result;
        }

        public Result<LoginItem> Update(LoginItem loginItem)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUserName(string userId, string password)
        {
            Result<LoginItem> Result = new Result<LoginItem>();

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("LoginVerification", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@password", password);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new LoginItem();

                            item.Id = Guid.Parse(dr["Id"].ToString());
                            item.UserName = dr["UserName"].ToString();
                            item.CreationDate = (DateTime)dr["DateCreated"];
                            item.IsValid = bool.Parse(dr["IsValid"].ToString());

                            Result.Data = item;
                        }
                    }
                    cn.Close();
                    Result.Success = true;
                }

                if (Result.Data == null)
                {
                    Result.Success = false;
                    Result.Message = $"Unable to validate user ID {userId}";
                }
            }
            catch (Exception e)
            {
                Result.Message = e.Message;
                Result.Success = false;
            }

            return Result.Success;
        }
    }
}
