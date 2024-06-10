using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Helpers;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels.Slider;

namespace MiniProjectMVC.Areas.Admin
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        public readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index(int page = 1)
        //{
        //    var sliders = await _sliderService.GetAllPaginateSlidersAsync(page, 4); 
        //    var mappedDatas =  _sliderService.GetMappedDatas(sliders);
        //    int totalPage = await GetPageCountAsync(4);
        //    Paginate<SliderAdminVM> response = new(mappedDatas, totalPage, page);



        //    return View(response);
        //}
        //private async Task<int> GetPageCountAsync(int take)
        //{
        //    int sliderCount = await _sliderService.GetCountAsync();

        //    return (int)Math.Ceiling((decimal)sliderCount / take);
        //}
    }
}
