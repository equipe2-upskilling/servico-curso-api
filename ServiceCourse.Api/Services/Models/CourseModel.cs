namespace ServiceCourse.Api.Services.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public int? Duration { get; set; }
        public double? Price { get; set; }
        public int? Enrollmentstatusid { get; set; }
    }
}
