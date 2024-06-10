
using MiniProjectMVC.Models;
using MiniProjectMVC.ViewModels.Slider;
using System.Reflection;

namespace MiniProjectMVC.Services.Interfaces
{
    public interface ISliderService
    {
        
        Task <IEnumerable<Slider>> GetAllSlidersAsync();
        Task<IEnumerable<Slider>> GetAllPaginateSlidersAsync(int page, int take);
        IEnumerable<SliderAdminVM> GetMappedDatas(IEnumerable<Slider> sliders);
        Task<int> GetCountAsync();
        Task CreateAsync(SliderCreateVM request);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(string title, string description);

    }
}
