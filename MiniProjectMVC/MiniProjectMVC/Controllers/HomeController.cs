using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels;
using MiniProjectMVC.Models;
using System.Runtime.CompilerServices;

namespace MiniProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IInfoService _infoService;
        private readonly IAboutService _aboutService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public HomeController(ISliderService sliderService,
                                 IInfoService infoService,
                                 IAboutService aboutService,
                                 ICategoryService categoryService,
                                 ICourseService courseService)
        {

            _courseService = courseService;
            _sliderService = sliderService;
            _infoService = infoService;
            _aboutService = aboutService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new()
            {
                Sliders = await _sliderService.GetAllSlidersAsync(),
                Infos = await _infoService.GetAllInfoAsync(),
                Abouts = await _aboutService.GetAllAboutAsync(),
                Categories = await _categoryService.GetAllCategoriesAsync(),
                Courses =await _courseService.GetAllCoursesAsync()
            };

            return View(model);
        }

    }
}

