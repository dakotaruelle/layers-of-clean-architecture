using Entities;
using Interactors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentsInteractor _studentsInteractor;

    public StudentsController(StudentsInteractor studentsInteractor)
    {
        _studentsInteractor = studentsInteractor;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _studentsInteractor.GetStudents();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UIStudentCourses>> GetStudentWithCourses(int id)
    {
        var student = await _studentsInteractor.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }

        var studentsPresenter = new StudentsPresenter();
        return studentsPresenter.MapToUiStudentCourses(student);
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
