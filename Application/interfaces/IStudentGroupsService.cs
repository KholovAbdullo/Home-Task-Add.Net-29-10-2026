using Application.DTOs.StudentGroups;
using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IStudentGroupsService
{
    Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto group);
    Task<ApiResponse<bool>> UpdateStudentGroup(int id,UpdateStudentGroupDto group);
    Task<ApiResponse<bool>> DeleteStudentGroup(int groupId);
    Task<ApiResponse<StudentGroupDto>> GetStudentGroup(int groupId);
    Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups();
}
