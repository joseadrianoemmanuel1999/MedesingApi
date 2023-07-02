using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedesingApi.Model;
using MedesingApi.Shared;

namespace MedesingApi.Service.UserService
{
    public interface IUser
    {
        Task<RegisterDto> RegisterUser (RegisterDto request);
       Task <User> LoginUser (LoginDto request);
   //Task<bool> EmmailVerification (RegisterDto request);
    }
}