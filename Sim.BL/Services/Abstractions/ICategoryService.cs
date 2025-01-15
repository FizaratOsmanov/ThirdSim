using Sim.BL.DTOs.CategoryDTOs;
using Sim.BL.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryGetDTO>> GetAllCategoryAsync();
        Task<CategoryGetDTO> GetCategoryByIdAsync(int Id);
        Task CreateCategoryAsync(CategoryPostDTO dto);
        Task DeleteCategory(int id);
    }
}
