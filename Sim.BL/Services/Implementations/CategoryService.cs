using AutoMapper;
using Sim.BL.DTOs.CategoryDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;

namespace Sim.BL.Services.Implementations
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CategoryPostDTO dto)
        {
            Category category = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(category);
            int result = await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryGetDTO>> GetAllCategoryAsync()
        {

            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<ICollection<CategoryGetDTO>>(categories);
        }

    

        public async Task<CategoryGetDTO> GetCategoryByIdAsync(int Id)
        {
            var dto = await _categoryRepository.GetByIdAsync(Id);
            return _mapper.Map<CategoryGetDTO>(dto);
        }

        public Task UpdateCategory(CategoryPutDTO dto)
        {
            throw new NotImplementedException();
        }

    }
}
