using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi;

[PrimaryKey(nameof(StudentId))]
public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

[PrimaryKey(nameof(CourseId))]
public class Course
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public string Title { get; set; }
}
