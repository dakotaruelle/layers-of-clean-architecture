namespace Entities;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public List<Course> Courses { get; set; }

    public string GetFullname()
    {
        return $"{FirstName} {LastName}";
    }
}
