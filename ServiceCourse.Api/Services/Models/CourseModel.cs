using static ServiceCourse.Api.Services.Models.CourseModel;

namespace ServiceCourse.Api.Services.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            Lessons = new List<LessonModel>();
        }
        public int CourseId { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public int? Duration { get; set; }
        public double? Price { get; set; }
        public int? Enrollmentstatusid { get; set; }
        public string? CoverImg { get; set; }
        public int? TeacherId { get; set; }
        public List<LessonModel> Lessons { get; set; }
        public class LessonModel
        {
            public int Lessonid { get; set; }

            public int? Courseid { get; set; }

            public string? Name { get; set; }

            public string? Description { get; set; }

            public string? Lessonurl { get; set; }

            public string? Image { get; set; }

            public DateTime? Registerdate { get; set; }
        }
    }
}
