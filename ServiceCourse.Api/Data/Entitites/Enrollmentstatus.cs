using System;
using System.Collections.Generic;

namespace ServiceCourse.Api.Data.Entitites;

public partial class Enrollmentstatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
