using MiniProjectMVC.Models;

namespace MiniProjectMVC.Services.Interfaces
{
    public interface IAboutService
    {
        public Task<IEnumerable<About>> GetAllAboutAsync();
    }
}
