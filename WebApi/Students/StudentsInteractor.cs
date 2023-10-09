namespace WebApi;

public class StudentsInteractor
{
    private readonly StudentsGateway _studentsGateway;

    public StudentsInteractor(StudentsGateway studentsGateway)
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
