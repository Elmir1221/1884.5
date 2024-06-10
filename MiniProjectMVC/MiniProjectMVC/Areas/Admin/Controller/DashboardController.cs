using Microsoft.AspNetCore.Mvc;

namespace MiniProjectMVC.Areas.Admin
{
    [Area("Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
