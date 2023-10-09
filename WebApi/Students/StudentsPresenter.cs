namespace WebApi;

public class StudentsPresenter
{
    public UIStudentCourses MapToUiStudentCourses(Student student)
    {
        var uiCourses = student.Courses.Select(course => new UICourse { Id = course.CourseId, Title = course.Title })
            .ToList();

        var studentCourses = new UIStudentCourses
        {
            Fullname = $"{student.FirstName} {student.LastName}",
            Courses = uiCourses
        };

        return studentCourses;
    }
}
