using Microsoft.EntityFrameworkCore;
using ServiceCourse.Api.Data.Entitites;
using ServiceCourse.Api.Data.Interfaces;

namespace ServiceCourse.Api.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context) => _context = context;
        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync().ConfigureAwait(false);
        }
    }
}
