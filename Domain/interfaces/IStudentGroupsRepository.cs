using Domain.Models;

namespace Domain.interfaces;

public interface IStudentGroupsRepository
{
    bool AddStudentGroup(StudentGroups group);
    bool UpdateStudentGroup(StudentGroups group);
    bool DeleteStudentGroup(int groupId);
    StudentGroups GetStudentGroup(int groupId);
    List<StudentGroups> GetStudentGroups();
}
