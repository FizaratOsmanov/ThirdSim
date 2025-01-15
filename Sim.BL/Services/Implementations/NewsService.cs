using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Sim.BL.DTOs.NewsDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;
using Sim.DAL.Repositories.Implementations;


namespace Sim.BL.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewsService(INewsRepository newsRepository,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task CreateNewsAsync(NewsPostDTO dto)
        {
            News news = _mapper.Map<News>(dto);

            string rootPath = _webHostEnvironment.WebRootPath;
            string fileName = dto.Image.FileName;
            string folderPath = rootPath + "/UPLOAD/NEWs/";
            string filePath = Path.Combine(folderPath, fileName);

            bool exists = Directory.Exists(folderPath);

            if (!exists)
            {
                Directory.CreateDirectory(folderPath);
            }

            string[] allowedExtensions = [".png", ".jpg", ".jpeg"];
            bool isAllowed = false;
            foreach (string extention in allowedExtensions)
            {
                if (Path.GetExtension(fileName) == extention)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                throw new Exception("File not supported");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }
            news.ImgPath = fileName;

            await _newsRepository.AddAsync(news);
            int result = await _newsRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Couldnt added News.");
            }
        }

        public async Task DeleteNews(int id)
        {
            News news = await _newsRepository.GetByIdAsync(id);
            _newsRepository.Delete(news);
            await _newsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<NewsGetDTO>> GetAllNewsAsync()
        {

            var news =  await _newsRepository.GetAllAsync();

            return _mapper.Map<ICollection<NewsGetDTO>>(news);
        }
        public async Task<NewsGetDTO> GetNewsByIdAsync(int Id)
        {
            var dto = await _newsRepository.GetByIdAsync(Id);    
            if (dto is null)
            {
                throw new Exception("Error");
            }
            return _mapper.Map<NewsGetDTO>(dto);
        }
        public Task UpdateNews(NewsPutDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
