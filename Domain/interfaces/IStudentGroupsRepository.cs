using Domain.Models;

namespace Domain.interfaces;

public interface IStudentGroupsRepository
{
    Task<bool> AddStudentGroup(StudentGroups group);
    Task<bool> UpdateStudentGroup(StudentGroups group);
    Task<bool> DeleteStudentGroup(int groupId);
    Task<StudentGroups> GetStudentGroup(int groupId);
    Task<List<StudentGroups>> GetStudentGroups();
}
