namespace WebApi;

public class UIStudentCourses
{
    public string Fullname { get; set; }
    public IEnumerable<UICourse> Courses { get; set; }
}

public class UICourse
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class CourseRequest
{
    public string Title { get; set; }
}
