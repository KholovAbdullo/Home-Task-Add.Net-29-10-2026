using Domain.Models;

namespace Application.interfaces;

public interface IStudentServices
{
    void AddStudent(Students student);
    void UpdateStudent(Students student);
    void DeleteStudent(int studentId);
    void GetStudent(int studentId);
    void GetAllStudents();
}
