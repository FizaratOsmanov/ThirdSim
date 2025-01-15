using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sim.BL.DTOs.CategoryDTOs;
using Sim.BL.DTOs.NewsDTOs;
using Sim.BL.Services.Abstractions;

namespace Sim.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly INewsService _newsService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        public CategoryController(INewsService newsService, IMapper mapper, ICategoryService categoryService)
        {
            _newsService = newsService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<CategoryGetDTO> category = await _categoryService.GetAllCategoryAsync();
            return View(category);
        }

        public IActionResult Create()
        {
            ViewBag.Category = _categoryService.GetAllCategoryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDTO dto)
        {
            await _categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
