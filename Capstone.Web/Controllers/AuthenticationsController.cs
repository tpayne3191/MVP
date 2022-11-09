using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Capstone.Core.Interfaces;

namespace Capstone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepository;

        public AuthenticationsController(IAuthenticationRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost, Route("login/{id}")]
        public IActionResult SetPlayerId(LoginModel user, int id)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (_authRepository.ValidateUserName(user.UserName, user.Password, id)) //TODO: have this return a user, store in a variable and check against if null
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5001",
                    audience: "http://localhost:5001",
                    claims: new List<Claim>()
                    {
                        new Claim("fullName", $"{user.UserName}"),
                        new Claim("playerId", id.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
