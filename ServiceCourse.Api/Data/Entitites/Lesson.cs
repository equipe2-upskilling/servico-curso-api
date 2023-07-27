namespace ServiceCourse.Api.Data.Entitites
{
    public partial class Lesson
    {
        public int Lessonid { get; set; }

        public int? Courseid { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Lessonurl { get; set; }

        public string? Image { get; set; }

        public DateTime? Registerdate { get; set; }

        public virtual Course? Course { get; set; }
    }
}
