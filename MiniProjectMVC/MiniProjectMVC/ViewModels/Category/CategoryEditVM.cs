namespace MiniProjectMVC.ViewModels.Category
{
    public class CategoryEditVM
    {
        public string Course { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }

    }
}
