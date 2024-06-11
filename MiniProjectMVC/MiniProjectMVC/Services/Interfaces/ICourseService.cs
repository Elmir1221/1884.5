

using MiniProjectMVC.Models;
using MiniProjectMVC.ViewModels.Course;

namespace MiniProjectMVC.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllPaginateAsync(int page, int take);
        IEnumerable<CourseAdminVM> GetMappedDatas(IEnumerable<Course> courses);
        Task CreateAsync(CourseCreateVM request);
        Task DeleteAsync(Course course);
        Task EditAsync(Course course, CourseEditVM request);


        //Task EditAsync(Course course, CourseEditVM request);
        // Task DeleteCourseImageAsync(MainAndDeleteImageVM data);
    }
}
