using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using MedesingApi.Db;
using MedesingApi.Model;
using MedesingApi.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MedesingApi.Model.Exceptions;
using MedesingApi.Token;
using System.Web;
using Microsoft.AspNetCore.Http;
using Azure;
using System.Net;
using Microsoft.Net.Http;

namespace MedesingApi.Service.UserService

{
    public class UserService : IUser
    {
       private readonly IConfiguration _configuration;
        private readonly Appcontext _appContext;
        private readonly IMapper _mapper;
          public UserService(Appcontext appContext,IMapper mapper,IConfiguration configuration)
        {
            _appContext = appContext;
            _mapper = mapper;
            _configuration = configuration;
            
        }

        public async Task<User> LoginUser(LoginDto request)
        {
            var user = _appContext.Users.FirstOrDefault(c=>c.email==request.email);
            if(user is null)
            {
              throw new EmmailNotfound(user);
            }
            
      
              if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
              throw new Exception("Wrong Password");
               string token = CreateToken(user);

            return(user);
            
          

        }
        public async Task EmmailVerification (string request)
        {
          var EmailVerification=  _appContext.Users.FirstOrDefault(c=>c.email==request);
            if( EmailVerification != null)
            {
             
              throw new EmmailNotfound(EmailVerification);
            }
           
        }

        public async Task<RegisterDto> RegisterUser(RegisterDto request)
        { 
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt); 
           await EmmailVerification(request.email);
           var user = new User {
                FirstName = request.FirstName,
                SurName = request.SurName,
                email=request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = Roles.User
           };
           
           await _appContext.AddAsync(user);
           await _appContext.SaveChangesAsync();
            var userResult = _mapper.Map<RegisterDto>(user); 
            
            return userResult ;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        
              
    } private  string CreateToken(User user)
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
 private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }
 
      

}
}