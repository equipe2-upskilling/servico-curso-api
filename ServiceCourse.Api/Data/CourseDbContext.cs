using Microsoft.EntityFrameworkCore;
using ServiceCourse.Api.Data.Entitites;

namespace ServiceCourse.Api.Data
{
    public partial class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Enrollmentstatus> Enrollmentstatuses { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Courseid).HasName("courses_pkey");

                entity.ToTable("courses");

                entity.Property(e => e.Courseid)
                    .HasDefaultValueSql("nextval('courses_id_seq'::regclass)")
                    .HasColumnName("courseid");
                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.Enrollmentstatusid).HasColumnName("enrollmentstatusid");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Registerdate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("registerdate");

                entity.HasOne(d => d.Enrollmentstatus).WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Enrollmentstatusid)
                    .HasConstraintName("courses_enrollmentstatusid_fkey");
            });

            modelBuilder.Entity<Enrollmentstatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("enrollmentstatus_pkey");

                entity.ToTable("enrollmentstatus");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
                entity.Property(e => e.Salt)
                    .HasMaxLength(255)
                    .HasColumnName("salt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
