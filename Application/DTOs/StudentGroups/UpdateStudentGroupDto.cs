using Domain.Enames;

namespace Application.DTOs.StudentGroups;

public class UpdateStudentGroupDto
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupsStatus Status { get; set; }
}
