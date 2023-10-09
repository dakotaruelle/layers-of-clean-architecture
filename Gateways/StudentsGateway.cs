using Interactors;
using Microsoft.EntityFrameworkCore;

namespace Gateways;

public class StudentsGateway : IStudentsGateway
{
    private readonly DatabaseContext _context;

    public StudentsGateway(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        var students = await _context.Students.ToListAsync();

        return students.Select(s => MapToStudent(s, new List<CourseEF>()));
    }

    public async Task<Student> GetStudent(int studentId)
    {
        var student = await _context.Students
            .Where(student => student.StudentId == studentId)
            .FirstOrDefaultAsync();
        var courses = await GetCoursesForStudent(studentId);

        return MapToStudent(student, courses);
    }

    private async Task<IEnumerable<CourseEF>> GetCoursesForStudent(int studentId)
    {
        return await _context.Courses.Where(c => c.StudentId == studentId).ToListAsync();
    }

    public async Task AddCourseForStudent(int studentId, string courseTitle)
    {
        _context.Courses.Add(new CourseEF { Title = courseTitle, StudentId = studentId });
        await _context.SaveChangesAsync();
    }

    private Student MapToStudent(StudentEF student, IEnumerable<CourseEF> courses)
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
