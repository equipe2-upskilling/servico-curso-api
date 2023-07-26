using ServiceCourse.Api.Data.Entitites;
using ServiceCourse.Api.Data.Interfaces;
using ServiceCourse.Api.Data;
using ServiceCourse.Api.Services.Interfaces;
using ServiceCourse.Api.Util;
using ServiceCourse.Api.Services.Models;

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

        public async Task<ServiceResult<CourseModel>> GetCourseAsync(int id)
        {
            var result = new ServiceResult<CourseModel>();
            var course = await _courseRepository.GetCourseAsync(id);

            if (course == null)
                return result.SetError("O curso não existe");

            var courseResult = new CourseModel()
            {
                CourseId = course.Courseid,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                Price = course.Price,
                Enrollmentstatusid = course.Enrollmentstatusid,
            };

            result.SetSuccess(courseResult);
            return result;
        }

        public async Task<ServiceResult<List<CourseModel>>> GetCoursesAsync()
        {
            var result = new ServiceResult<List<CourseModel>>();
            var courses = await _courseRepository.GetCoursesAsync();

            if (courses == null || !courses.Any())
                return result.SetError("Nenhum curso encontrado");

            var courseResults = courses.Select(course => new CourseModel
            {
                CourseId = course.Courseid,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                Price = course.Price,
                Enrollmentstatusid = course.Enrollmentstatusid
            }).ToList();

            result.SetSuccess(courseResults);
            return result;
        }

    }
}
