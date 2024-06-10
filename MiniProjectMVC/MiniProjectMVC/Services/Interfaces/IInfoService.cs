using MiniProjectMVC.Models;

namespace MiniProjectMVC.Services.Interfaces
{
    public interface IInfoService
    {
        public Task<IEnumerable<Info>> GetAllInfoAsync();

    }
}
