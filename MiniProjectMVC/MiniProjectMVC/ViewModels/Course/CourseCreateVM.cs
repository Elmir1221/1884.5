using System.ComponentModel.DataAnnotations;

namespace MiniProjectMVC.ViewModels.Course
{
    public class CourseCreateVM
    {
        [Required]
        public int StudentCount { get; set; }
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Teacher { get; set; }
        
        [Required]
        public List<IFormFile> Image { get; set; }
        
        [Required]
        public decimal Price { get; set; }

    }
}
