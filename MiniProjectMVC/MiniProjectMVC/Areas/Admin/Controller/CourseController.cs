using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Helpers.Extention;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels.Course;

namespace MiniProjectMVC.Areas.Admin
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        public CourseController(
           ICourseService courseService,
           ICategoryService categoryService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = _categoryService.GetAllSelectedAsync().Result.OrderBy(m => m.Text);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(CourseCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = _categoryService.GetAllSelectedAsync().Result.OrderBy(m => m.Text);
                return View();
            }

            foreach (var item in request.Image)
            {
                if (!item.CheckFileSize(500))
                {
                    ModelState.AddModelError("Images", "Image size can be max 500 Kb");
                    ViewBag.categories = _categoryService.GetAllSelectedAsync().Result.OrderBy(m => m.Text);
                    return View();
                }

                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File type must be only image");
                    ViewBag.categories = _categoryService.GetAllSelectedAsync().Result.OrderBy(m => m.Text);
                    return View();
                }
            }

            await _courseService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }
    }
}
