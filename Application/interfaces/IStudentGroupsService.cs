using Domain.Models;

namespace Application.interfaces;

public interface IStudentGroupsService
{
    Task AddStudentGroup(StudentGroups group);
    Task UpdateStudentGroup(StudentGroups group);
    Task DeleteStudentGroup(int groupId);
    Task GetStudentGroup(int groupId);
    Task GetAllStudentGroup();
    Task<decimal> GetCompletionRate();
}
