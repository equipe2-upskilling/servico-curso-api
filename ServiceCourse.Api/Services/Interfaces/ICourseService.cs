using ServiceCourse.Api.Data.Entitites;

namespace ServiceCourse.Api.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> GetCourseAsync(int id);
        Task<List<Course>> GetCoursesAsync();
    }
}
