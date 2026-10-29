using Domain.Enames;

namespace Domain.Models;

public class StudentGroups
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupsStatus Status { get; set; }
}