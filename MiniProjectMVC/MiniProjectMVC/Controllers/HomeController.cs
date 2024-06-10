using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels;

namespace MiniProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IInfoService _infoService;
        private readonly IAboutService _aboutService;

        public HomeController(ISliderService sliderService,
                                 IInfoService infoService,
                                 IAboutService aboutService)
        {
            _sliderService = sliderService;
            _infoService = infoService;
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new() 
            {
                Sliders = await _sliderService.GetAllSlidersAsync(),
                Infos = await _infoService.GetAllInfoAsync(),
                Abouts = await _aboutService.GetAllAboutAsync()
            };

            return View(model);
        }

    }
}

