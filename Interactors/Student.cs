namespace Interactors;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public List<Course> Courses { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public string Title { get; set; }
}
