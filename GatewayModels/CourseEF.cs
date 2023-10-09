using Microsoft.EntityFrameworkCore;

namespace GatewayModels;

[PrimaryKey(nameof(CourseId))]
public class CourseEF
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public string Title { get; set; }
}
