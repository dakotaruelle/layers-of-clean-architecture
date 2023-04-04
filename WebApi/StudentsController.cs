using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly DatabaseContext _context;

    public StudentsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }

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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UIStudentCourses>> GetStudentWithCourses(int id)
    {
        var student = await _context.Students
            .Where(student => student.StudentId == id)
            .FirstOrDefaultAsync();
        var courses = await _context.Courses.Where(course => course.StudentId == id).ToListAsync();
    
        if (student == null)
        {
            return NotFound();
        }
    
        var studentCourses = new UIStudentCourses
        {
            Fullname = $"{student.FirstName} {student.LastName}",
            Courses = courses.Select(course => new UICourse { Id = course.CourseId, Title = course.Title }).ToList()
        };
    
        return studentCourses;
    }

    public class CourseRequest
    {
        public string Title { get; set; }
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> AddCourseForStudent(int id, CourseRequest courseRequest)
    {
        var existingStudent = await _context.Students.Where(s => s.StudentId == id).FirstOrDefaultAsync();
        if (existingStudent == null)
        {
            return BadRequest();
        }
        
        var existingCourses = await _context.Courses.Where(c => c.StudentId == id).ToListAsync();
        if (existingCourses.Any(existingCourse => existingCourse.Title == courseRequest.Title))
        {
            return BadRequest();
        }
        
        _context.Courses.Add(new Course { Title = courseRequest.Title, StudentId = id });
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}
