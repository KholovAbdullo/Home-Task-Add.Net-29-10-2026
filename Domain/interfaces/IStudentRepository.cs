using Domain.Models;

namespace Domain.interfaces;

public interface IStudentRepository
{
    Task<bool> AddStudent(Students student);
    Task<bool> UpdateStudent(Students student);
    Task<bool> DeleteStudent(int studentId);
    Task<Students> GetStudent(int studentId);
    Task<List<Students>> GetStudents();
    Task<List<Students>> GetStudentsWithGroups();
    Task<List<Students>> GetStudentsWithoutGroups();
    Task<List<Students>> GetDroppedOutStudents();
    Task<List<Students>> GetGraduatedStudents();
}
