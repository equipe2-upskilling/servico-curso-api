using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using ServiceCourse.Api.Data;

namespace ServiceCourse.Test.Configuration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextInMemory(this IServiceCollection services)
        {
            var inMemoryDatabaseRoot = new InMemoryDatabaseRoot();

            services.AddDbContextFactory<CourseDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString(), inMemoryDatabaseRoot, b => b.EnableNullChecks(false));
                options.EnableServiceProviderCaching(false);
            });
        }
    }
}
