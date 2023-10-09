namespace Interactors;

public class StudentsInteractor
{
    private readonly IStudentsGateway _studentsGateway;

    public StudentsInteractor(IStudentsGateway studentsGateway)
    {
        _studentsGateway = studentsGateway;
    }

    public async Task<bool> AddCourseForStudent(int studentId, string courseTitle)
    {
        var existingStudent = await _studentsGateway.GetStudent(studentId);
        if (existingStudent == null)
        {
            return false;
        }

        if (existingStudent.Courses.Any(existingCourse => existingCourse.Title == courseTitle))
        {
            return false;
        }

        await _studentsGateway.AddCourseForStudent(studentId, courseTitle);

        return true;
    }
}
