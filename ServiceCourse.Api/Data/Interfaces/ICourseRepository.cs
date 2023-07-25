using ServiceCourse.Api.Data.Entitites;

namespace ServiceCourse.Api.Data.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseAsync(int id);
        Task<List<Course>> GetCoursesAsync();
    }
}
