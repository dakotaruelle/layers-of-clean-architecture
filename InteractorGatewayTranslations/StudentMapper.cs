using GatewayModels;
using Interactors;

namespace InteractorGatewayTranslations;

public static class StudentMapper
{
    public static Student MapToStudent(StudentEF student, IEnumerable<CourseEF> courses)
    {
        return new Student
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            EnrollmentDate = student.EnrollmentDate,
            Courses = courses
                .Select(c => new Course { CourseId = c.CourseId, StudentId = c.StudentId, Title = c.Title }).ToList()
        };
    }
}
