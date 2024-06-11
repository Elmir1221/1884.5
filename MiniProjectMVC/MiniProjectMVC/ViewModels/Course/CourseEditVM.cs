using System.ComponentModel.DataAnnotations;

namespace MiniProjectMVC.ViewModels.Course
{
    public class CourseEditVM
    {
        [Required]
        public int StudentCount { get; set; }
        [Required]
        public int Duration { get; set; }
        public string Teacher { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Price { get; set; }
      
        public int CategoryIdCourseImageVM { get; set; }
        public List<CourseImageVM> Images { get; set; }
        public List<IFormFile> NewImages { get; set; }
    }
}
