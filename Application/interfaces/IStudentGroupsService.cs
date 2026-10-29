using Domain.Models;

namespace Application.interfaces;

public interface IStudentGroupsService
{
    void AddStudentGroup(StudentGroups group);
    void UpdateStudentGroup(StudentGroups group);
    void DeleteStudentGroup(int groupId);
    void GetStudentGroup(int groupId);
    void GetAllStudentGroup();
}
