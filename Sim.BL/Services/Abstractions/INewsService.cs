using Sim.BL.DTOs.NewsDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Abstractions
{
    public interface INewsService
    {
        Task<ICollection<NewsGetDTO>> GetAllNewsAsync();
        Task<NewsGetDTO> GetNewsByIdAsync(int Id);
        Task CreateNewsAsync(NewsPostDTO dto);
        Task UpdateNews(NewsPutDTO dto);
        Task DeleteNews(int id);
    }
}
