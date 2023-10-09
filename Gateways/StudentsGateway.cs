using GatewayModels;
using InteractorGatewayTranslations;
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

        return students.Select(s => StudentMapper.MapToStudent(s, new List<CourseEF>()));
    }

    public async Task<Student> GetStudent(int studentId)
    {
        var student = await _context.Students
            .Where(student => student.StudentId == studentId)
            .FirstOrDefaultAsync();
        var courses = await GetCoursesForStudent(studentId);

        return StudentMapper.MapToStudent(student, courses);
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
}
