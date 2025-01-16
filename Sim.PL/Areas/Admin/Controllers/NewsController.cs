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
        public NewsController(INewsService newsService, IMapper mapper, ICategoryService categoryService)
        {
            _newsService = newsService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<NewsGetDTO> news = await _newsService.GetAllNewsAsync();
            return View(news);
        }

        public IActionResult Create()
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

        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.DeleteNews(id);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Update(int Id)
        //{
        //    ViewBag.Category = await _categoryService.GetAllCategoryAsync();
        //    NewsGetDTO dto = await _newsService.GetNewsByIdAsync(Id);
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(NewsPutDTO dto)
        //{
        //    ViewBag.Category = await _categoryService.GetAllCategoryAsync();
        //    await _newsService.UpdateNews(dto);
        //    return RedirectToAction("Index");

        //}
    }
}
