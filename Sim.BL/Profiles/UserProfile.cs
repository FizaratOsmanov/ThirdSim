using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sim.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<LoginDTO,IdentityUser>().ReverseMap();
            CreateMap<RegisterDTO,IdentityUser>().ReverseMap();
        }
    }
}
