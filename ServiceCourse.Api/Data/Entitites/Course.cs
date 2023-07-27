namespace ServiceCourse.Api.Data.Entitites;

public partial class Course
{
    public int Courseid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public double? Price { get; set; }

    public int? Enrollmentstatusid { get; set; }

    public DateTime? Registerdate { get; set; }

    public string? Coverimg { get; set; }

    public int? Teacherid { get; set; }

    public virtual Enrollmentstatus? Enrollmentstatus { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
