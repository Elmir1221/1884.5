namespace MiniProjectMVC.Models
{
    public class Course:BaseEntity
    {
        public int StudentCount { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }
        public ICollection<CourseImage> Image { get; set; }
        public decimal Price { get; set; }


    }
}
