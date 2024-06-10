using System.ComponentModel.DataAnnotations;

namespace MiniProjectMVC.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreatedTime { get; set; }
        [Required]
        public IFormFile Images { get; set; }
    }
}
