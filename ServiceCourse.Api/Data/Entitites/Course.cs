namespace ServiceCourse.Api.Data.Entitites
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Duration { get; set; }
        public float Price { get; set; }
    }
}
