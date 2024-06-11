using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Helpers;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels.Category;

namespace MiniProjectMVC.Areas.Admin
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }



        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var categories = await _categoryService.GetAllPaginateAsync(page, 4);

            var mappedDatas = _categoryService.GetMappedDatas(categories);

            var totalPage = await GetPageCountAsync(4);

            Paginate<CategoryCourseVM> response = new(mappedDatas, totalPage, page);

            return View(response);

        }
        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _categoryService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
    }
}

