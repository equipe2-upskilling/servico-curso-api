using ServiceCourse.Api.Data.Entitites;
using ServiceCourse.Api.Data.Interfaces;
using ServiceCourse.Api.Data;
using ServiceCourse.Api.Services.Interfaces;

namespace ServiceCourse.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _uow;
        public CourseService(ICourseRepository courseRepository,
                                IUnitOfWork uow)

        {
            _courseRepository = courseRepository;
            _uow = uow;
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _courseRepository.GetCourseAsync(id);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }
    }
}
