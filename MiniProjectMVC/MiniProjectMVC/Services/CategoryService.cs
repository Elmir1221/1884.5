using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.Data;
using MiniProjectMVC.Models;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels.Category;
using MiniProjectMVC.Helpers.Extention;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniProjectMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryService (AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
       

        public async Task CreateAsync(CategoryCreateVM request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.Image.FileName}";

            string path = _env.GenerateFilePath("assets/img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Categories.AddAsync(new Category
            {
                Course = request.Course.Trim(),
                Count = request.Count,
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

       

        public async Task DeleteAsync(Category category)
        {
            string imagePath = _env.GenerateFilePath("assets/img", category.Image);
            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Category category, CategoryEditVM request)
        {
            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("assets/images", category.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("assets/images", fileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);

                category.Image = fileName;
            }

            category.Course = request.Course.Trim();
            category.Count = request.Count;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                
                .ToListAsync();
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var categories = await _context.Categories
               .ToListAsync();

            return new SelectList(categories, "Id", "Name");
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public IEnumerable<CategoryCourseVM> GetMappedDatas(IEnumerable<Category> categories)
        {
            return categories.Select(m => new CategoryCourseVM
            {
                Course=m.Course,
                Image=m.Image,
                Count = m.Count,
            });
        }
    }
}
