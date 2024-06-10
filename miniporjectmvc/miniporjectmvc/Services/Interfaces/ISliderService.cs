using miniporjectmvc.Models;

namespace miniporjectmvc.Services.Interfaces
{
    public interface ISliderService
    {
        
        Task <IEnumerable<Slider>> GetAllSlidersAsync();
    }
}
