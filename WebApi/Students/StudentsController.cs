using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentsGateway _studentsGateway;
    private readonly StudentsInteractor _studentsInteractor;

    public StudentsController(StudentsGateway studentsGateway, StudentsInteractor studentsInteractor)
    {
        _studentsGateway = studentsGateway;
        _studentsInteractor = studentsInteractor;
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
        var result = await _studentsInteractor.AddCourseForStudent(id, courseRequest.Title);
        if (!result)
        {
            return BadRequest();
        }

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
