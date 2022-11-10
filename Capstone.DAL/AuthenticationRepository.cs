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
            var result = new Result<LoginItem>();
            
            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("AddLogin", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", loginItem.UserName);
                    cmd.Parameters.AddWithValue("@password", loginItem.Password);
                    cmd.Parameters.AddWithValue("@playerId", loginItem.PlayerId);

                    cn.Open();
                    cmd.ExecuteScalar();
                    cn.Close();
                    result.Data = loginItem;

                    if (result.Data != null)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = $"Failed to create login with User Name {loginItem.UserName}";
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result Delete(Guid loginItemId)
        {
            var loginResult = Get(loginItemId);

            if (!loginResult.Success)
            {
                return loginResult;
            }

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("DeleteLogin", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", loginResult.Data.UserName);

                    cn.Open();
                    cmd.ExecuteScalar();
                    cn.Close();

                    if (loginResult.Data != null)
                    {
                        loginResult.Success = true;
                    }
                    else
                    {
                        loginResult.Success = false;
                        loginResult.Message = $"Entity with user name {loginResult.Data.UserName} not found.";
                    }

                    return loginResult;
                }
            }
            catch (Exception ex)
            {
                loginResult.Success = false;
                loginResult.Message = ex.Message;
            }

            return loginResult;
        }

        public Result<LoginItem> Get(Guid loginItemUserId)
        {
            var result = new Result<LoginItem>();

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("ReadLoginById", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@loginId", loginItemUserId);


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

                            result.Data = item;
                        }
                    }
                    cn.Close();

                    if (result.Data != null)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = $"Entity with id {loginItemUserId} not found.";
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
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
            var result = new Result<LoginItem>();

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("UpdateLogin", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@loginId", loginItem.Id);
                    cmd.Parameters.AddWithValue("@userId", loginItem.UserName);
                    cmd.Parameters.AddWithValue("@password", loginItem.Password);
                    cmd.Parameters.AddWithValue("@dateCreated", loginItem.CreationDate);
                    cmd.Parameters.AddWithValue("@playerId", loginItem.PlayerId);

                    cn.Open();
                    cmd.ExecuteScalar();
                    cn.Close();
                    result.Data = loginItem;
                    result.Success = true;

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<LoginItem> ValidateUserName(string userId, string password)
        {
            Result<LoginItem> result = new Result<LoginItem>();

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.GetAuthConnectionstring()))
                {
                    var cmd = new SqlCommand("LoginVerification", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@password", password);
                    int tempPlayerId = 0;

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new LoginItem();

                            item.Id = Guid.Parse(dr["Id"].ToString());
                            item.UserName = dr["UserName"].ToString();
                            item.CreationDate = (DateTime)dr["DateCreated"];
                            Int32.TryParse(dr["PlayerId"].ToString(), out tempPlayerId);
                            item.PlayerId = tempPlayerId;

                            result.Data = item;
                        }
                    }
                    cn.Close();
                    result.Success = true;
                }

                if (result.Data == null)
                {
                    result.Success = false;
                    result.Message = $"Unable to validate user ID {userId}";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Success = false;
            }

            return result;
        }
    }
}
