using Entities;

namespace Interactors;

public interface IStudentsGateway
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> GetStudent(int studentId);
    Task AddCourseForStudent(int studentId, string courseTitle);
}
