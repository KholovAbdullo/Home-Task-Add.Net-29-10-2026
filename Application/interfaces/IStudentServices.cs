using Application.DTOs.Students;
using Application.Responses;

namespace Application.interfaces;

public interface IStudentServices
{
    Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto);
    Task<ApiResponse<bool>> UpdateStudent(int id,UpdateStudentDto studentDto);
    Task<ApiResponse<bool>> DeleteStudent(int studentId);
    Task<ApiResponse<StudentDto>> GetStudent(int studentId);
    Task<ApiResponse<List<StudentDto>>> GetStudents();
}
