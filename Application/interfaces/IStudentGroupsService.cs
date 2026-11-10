using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IStudentGroupsService
{
    Task<ApiResponse<bool>> AddStudentGroup(StudentGroups group);
    Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroups group);
    Task<ApiResponse<bool>> DeleteStudentGroup(int groupId);
    Task<ApiResponse<StudentGroups>> GetStudentGroup(int groupId);
    Task<ApiResponse<List<StudentGroups>>> GetStudentGroups();
}
