using AutoMapper;
using Sim.BL.DTOs.CategoryDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryGetDTO,Category>().ReverseMap();
            CreateMap<CategoryPostDTO,Category>().ReverseMap();
        }
    }
}
