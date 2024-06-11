using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.Data;
using MiniProjectMVC.Models;
using MiniProjectMVC.Services.Interfaces;
using MiniProjectMVC.ViewModels.Course;
using MiniProjectMVC.Helpers.Extention;

namespace MiniProjectMVC.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseService(AppDbContext context,
                             IWebHostEnvironment webHost)
        {
            _env = webHost;
            _context = context;
        }
     

        public async Task CreateAsync(CourseCreateVM request)
        {
            List<CourseImage> images = new();

            foreach (var item in request.Image)
            {
                string fileName = $"{Guid.NewGuid()}-{item.FileName}";

                string path = _env.GenerateFilePath("img", fileName);

                await item.SaveFileToLocalAsync(path);

                images.Add(new CourseImage { Name = fileName });
            }

            images.FirstOrDefault().IsMain = true;

            Course course = new()
            {
                StudentCount = request.StudentCount,
                Duration = request.Duration,
                Title = request.Title,
                Price = request.Price,
                Teacher = request.Teacher,
                Image = images
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

      

        public async Task DeleteAsync(Course course)
        {

            foreach (var item in course.Image)
            {
                string path = _env.GenerateFilePath("assets/img", item.Name);
                path.DeleteFileFromLocal();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Course course, CourseEditVM request)
        {
            if (request.NewImages is not null)
            {
                foreach (var item in request.NewImages)
                {
                    string fileName = $"{Guid.NewGuid()}-{item.FileName}";

                    string path = _env.GenerateFilePath("assets/images", fileName);

                    await item.SaveFileToLocalAsync(path);

                    course.Image.Add(new CourseImage { Name = fileName });
                }
            }

            course.StudentCount = request.StudentCount;
            course.Price = decimal.Parse(request.Price);
            course.Duration = request.Duration;
            course.Teacher = request.Teacher;
            course.Title = request.Title;




            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Courses
              .OrderByDescending(m => m.Id)
              .Skip((page - 1) * take)
              .Take(take)
              .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public IEnumerable<CourseAdminVM> GetMappedDatas(IEnumerable<Course> courses)
        {
            return courses.Select(m => new CourseAdminVM
            {
                
                StudentCount = m.StudentCount,
                Title = m.Title,
                Price = m.Price,
                Duration =m.Duration,
               
                Teacher=m.Teacher,
            });
        }
    }
}
