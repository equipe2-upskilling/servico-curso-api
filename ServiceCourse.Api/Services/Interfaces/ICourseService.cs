using ServiceCourse.Api.Data.Entitites;
using ServiceCourse.Api.Services.Models;
using ServiceCourse.Api.Util;

namespace ServiceCourse.Api.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ServiceResult<CourseModel>> GetCourseAsync(int id);
        Task<ServiceResult<List<CourseModel>>> GetCoursesAsync();
    }
}
