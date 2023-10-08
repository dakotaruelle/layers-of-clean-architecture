using Microsoft.EntityFrameworkCore;

namespace WebApi;

public class StudentsGateway
{
    private readonly DatabaseContext _context;

    public StudentsGateway(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetStudent(int studentId)
    {
        return await _context.Students
            .Where(student => student.StudentId == studentId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesForStudent(int studentId)
    {
        return await _context.Courses.Where(c => c.StudentId == studentId).ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task AddCourseForStudent(int studentId, string courseTitle)
    {
        _context.Courses.Add(new Course { Title = courseTitle, StudentId = studentId });
        await _context.SaveChangesAsync();
    }
}
