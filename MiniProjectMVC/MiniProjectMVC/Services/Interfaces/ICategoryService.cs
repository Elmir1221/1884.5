using Microsoft.AspNetCore.Mvc.Rendering;
using MiniProjectMVC.Models;
using MiniProjectMVC.ViewModels.Category;

namespace MiniProjectMVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<SelectList> GetAllSelectedAsync();
        Task<Category> GetByIdAsync(int id);
        Task<int> GetCountAsync();
        IEnumerable<CategoryCourseVM> GetMappedDatas(IEnumerable<Category> categories);
        Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take);
        Task CreateAsync(CategoryCreateVM request);
        Task EditAsync(Category category, CategoryEditVM request);
        Task DeleteAsync(Category category);

    }
}
