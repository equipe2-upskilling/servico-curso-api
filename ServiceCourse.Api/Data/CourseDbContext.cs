using Microsoft.EntityFrameworkCore;
using ServiceCourse.Api.Data.Entitites;

namespace ServiceCourse.Api.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
    }
}
