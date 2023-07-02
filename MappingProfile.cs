using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedesingApi.Model;
using MedesingApi.Shared;

namespace MedesingApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,RegisterDto>();
            CreateMap<User,RegisterDto>().ReverseMap();
            CreateMap<Post,EditpostDto>();
            CreateMap<User,LoginDto>();
        

        }
    }
}