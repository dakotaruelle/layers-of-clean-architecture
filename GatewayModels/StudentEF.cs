using Microsoft.EntityFrameworkCore;

namespace GatewayModels;

[PrimaryKey(nameof(StudentId))]
public class StudentEF
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
