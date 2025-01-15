using AutoMapper;
using Sim.BL.DTOs.NewsDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Profiles
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsGetDTO,News>().ReverseMap();
            CreateMap<NewsPutDTO,News>().ReverseMap();
            CreateMap<NewsPostDTO,News>().ReverseMap();
        }
    }
}
