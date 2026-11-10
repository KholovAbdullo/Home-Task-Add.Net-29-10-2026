using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IStudentServices
{
    Task<ApiResponse<bool>> AddStudent(Students student);
    Task<ApiResponse<bool>> UpdateStudent(Students student);
    Task<ApiResponse<bool>> DeleteStudent(int studentId);
    Task<ApiResponse<Students>> GetStudent(int studentId);
    Task<ApiResponse<List<Students>>> GetStudents();
}
