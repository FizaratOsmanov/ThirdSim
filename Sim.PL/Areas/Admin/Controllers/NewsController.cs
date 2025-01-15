using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sim.BL.DTOs.NewsDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;

namespace Sim.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        readonly INewsService _newsService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        public NewsController(INewsService newsService, IMapper mapper,ICategoryService categoryService)
        {
            _newsService = newsService;
            _mapper = mapper;
            _categoryService = categoryService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public   IActionResult Create()
        {
            ViewBag.Category = _categoryService.GetAllCategoryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsPostDTO dto)
        {
            await _newsService.CreateNewsAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
