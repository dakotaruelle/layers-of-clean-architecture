using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentsGateway _studentsGateway;

    public StudentsController(StudentsGateway studentsGateway)
    {
        _studentsGateway = studentsGateway;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _studentsGateway.GetAllStudents();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UIStudentCourses>> GetStudentWithCourses(int id)
    {
        var student = await _studentsGateway.GetStudent(id);
        var courses = await _studentsGateway.GetCoursesForStudent(id);
    
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

    [HttpPost("{id}")]
    public async Task<IActionResult> AddCourseForStudent(int id, CourseRequest courseRequest)
    {
        var existingStudent = await _studentsGateway.GetStudent(id);
        if (existingStudent == null)
        {
            return BadRequest();
        }

        var existingCourses = await _studentsGateway.GetCoursesForStudent(id);
        if (existingCourses.Any(existingCourse => existingCourse.Title == courseRequest.Title))
        {
            return BadRequest();
        }

        await _studentsGateway.AddCourseForStudent(id, courseRequest.Title);
        
        return Ok();
    }
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

public class CourseRequest
{
    public string Title { get; set; }
}
