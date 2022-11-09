using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public Result Delete(Guid loginItemId)
        {
            throw new NotImplementedException();
        }

        public Result<LoginItem> Get(Guid loginItemUserId)
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

        public Result<List<LoginItem>> GetAll()
        {
            Result<List<LoginItem>> result = new Result<List<LoginItem>>()
            {
                Data = new List<LoginItem>(),
                Success = true,
                Message = "Get all Login Items"
            };

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("GetAllLogins", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int tempPlayerId = 0;
                    
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new LoginItem();

                            item.Id = Guid.Parse(dr["Id"].ToString());
                            item.UserName = dr["UserName"].ToString();
                            item.Password = dr["Password"].ToString();
                            item.CreationDate = (DateTime)dr["DateCreated"];
                            Int32.TryParse(dr["PlayerId"].ToString(), out tempPlayerId);
                            item.PlayerId = tempPlayerId;

                            result.Data.Add(item);
                        }
                    }
                    cn.Close();

                    if (result.Data.Count > 0)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
                
                return result;
            }
        }

        public Result<LoginItem> Update(LoginItem loginItem)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUserName(string userId, string password, int playerId)
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
                            item.PlayerId = playerId;

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
