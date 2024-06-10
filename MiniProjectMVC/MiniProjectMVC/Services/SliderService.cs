using MiniProjectMVC.Data;
using MiniProjectMVC.Models;
using MiniProjectMVC.Helpers.Extention;
using MiniProjectMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.ViewModels.Slider;
using System.Reflection;

namespace MiniProjectMVC.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderService(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
           _context = context;
            _env = hostEnvironment;
        }

        public async Task CreateAsync(SliderCreateVM request)
        {
            string fileName= Guid.NewGuid().ToString() + "-" + request.Images.FileName;
            string path = _env.GenerateFilePath("img", fileName);
             await request.Images.SaveFileToLocalAsync(path);

            await _context.Sliders.AddAsync(new Slider
            {
                 Title = request.Title,
                 Description = request.Description,
                 Image = fileName
                 
                 
            });

        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            string imgParth = _env.GenerateFilePath("img", slider.Image);
            imgParth.DeleteFileFromLocal();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string title, string description)
        {
            return await _context.Sliders.AllAsync(m => m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim());
        }

        public async Task<IEnumerable<Slider>> GetAllPaginateSlidersAsync(int page, int take)
        {
            return await _context.Sliders.
                OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Slider>> GetAllSlidersAsync()
        {
            return await _context.Sliders.ToListAsync();

        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Sliders.CountAsync();

        }

        public  IEnumerable<SliderAdminVM> GetMappedDatas(IEnumerable<Slider> sliders)
        {
            return sliders.Select(m => new SliderAdminVM
            {
                Id = m.Id,
                Title = m.Title,
                Image = m.Image,
                CreatedTime = m.CreatedTime,
                Description = m.Description
            });
        }
    }
}
