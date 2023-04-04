namespace WebApi;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        // Look for any students.
        if (context.Students.Any())
        {
            return; // DB has been seeded
        }

        var students = new Student[]
        {
            new Student
            {
                FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2019-09-01")
            },
            new Student
            {
                FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2017-09-01")
            },
            new Student { FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2018-09-01") },
            new Student { FirstName = "Bruce", LastName = "Wayne", EnrollmentDate = DateTime.Parse("1996-06-26") },
        };

        context.Students.AddRange(students);
        context.SaveChanges();

        var courses = new Course[]
        {
            new Course { StudentId = 1, Title = "Chemistry" },
            new Course { StudentId = 1, Title = "Microeconomics" },
            new Course { StudentId = 2, Title = "Macroeconomics" },
            new Course { StudentId = 2, Title = "Calculus" },
            new Course { StudentId = 2, Title = "Trigonometry" },
            new Course { StudentId = 3, Title = "Composition" },
            new Course { StudentId = 3, Title = "Literature" }
        };

        context.Courses.AddRange(courses);
        context.SaveChanges();
    }
}
