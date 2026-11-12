using Domain.Models;

namespace Domain.interfaces;

public interface IStudentGroupsRepository
{
    Task<bool> AddStudentGroup(StudentGroups group);
    Task<bool> UpdateStudentGroup(int id,StudentGroups group);
    Task<bool> DeleteStudentGroup(int groupId);
    Task<StudentGroups> GetStudentGroup(int groupId);
    Task<List<StudentGroups>> GetStudentGroups();
    Task<List<Students>> GetStudentsInGroup(int groupId);
    Task<bool> UpdateStudentGroupStatus(int studentId, int groupId, string status);
}
