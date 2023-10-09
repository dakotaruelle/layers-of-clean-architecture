using GatewayModels;

namespace Gateways;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        // Look for any students.
        if (context.Students.Any())
        {
            return; // DB has been seeded
        }

        var students = new StudentEF[]
        {
            new StudentEF
            {
                FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2019-09-01")
            },
            new StudentEF
            {
                FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2017-09-01")
            },
            new StudentEF { FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2018-09-01") },
            new StudentEF { FirstName = "Bruce", LastName = "Wayne", EnrollmentDate = DateTime.Parse("1996-06-26") },
        };

        context.Students.AddRange(students);
        context.SaveChanges();

        var courses = new CourseEF[]
        {
            new CourseEF { StudentId = 1, Title = "Chemistry" },
            new CourseEF { StudentId = 1, Title = "Microeconomics" },
            new CourseEF { StudentId = 2, Title = "Macroeconomics" },
            new CourseEF { StudentId = 2, Title = "Calculus" },
            new CourseEF { StudentId = 2, Title = "Trigonometry" },
            new CourseEF { StudentId = 3, Title = "Composition" },
            new CourseEF { StudentId = 3, Title = "Literature" }
        };

        context.Courses.AddRange(courses);
        context.SaveChanges();
    }
}
