using Domain.Models;

namespace Application.interfaces;

public interface IStudentServices
{
    Task AddStudent(Students student);
    Task UpdateStudent(Students student);
    Task DeleteStudent(int studentId);
    Task GetStudent(int studentId);
    Task GetAllStudents();
    Task<List<Students>> GetStudentsWithGroups();
    Task<List<Students>> GetStudentsWithoutGroups();
    Task<List<Students>> GetDroppedOutStudents();
    Task<List<Students>> GetGraduatedStudents();
}
