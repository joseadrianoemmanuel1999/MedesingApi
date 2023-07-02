using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedesingApi.Service;
using MedesingApi.Shared;
using MedesingApi.Service.UserService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MedesingApi.Model;

namespace MedesingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _service;
        private readonly IConfiguration _configuration;
        public UserController (IUser service, IConfiguration configuration)
        {_service= service;
        _configuration =configuration;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> UserRegister (RegisterDto  request)
         
        {
         
            var newuser = await _service.RegisterUser(request);
            return Ok("sucess");
       }
       [HttpPost("Login")]
        public async Task<ActionResult> userlogin (LoginDto  request)
         
        {
         var user = await _service.LoginUser(request);
         string Token = CreateToken(user);
         return Ok(Token);
             
        }
         private  string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.email),
                new Claim(ClaimTypes.Role, "user"),
                
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

}
}