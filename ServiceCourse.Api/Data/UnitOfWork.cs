namespace ServiceCourse.Api.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Dispose();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseDbContext _context;

        public UnitOfWork(CourseDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
