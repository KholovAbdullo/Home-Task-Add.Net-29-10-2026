using Domain.Enames;

namespace Application.DTOs.StudentGroups;

public class StudentGroupDto
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupsStatus Status { get; set; }
}
