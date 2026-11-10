using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IGroupsService
{
    Task<ApiResponse<bool>> AddGroup(Groups group);
    Task<ApiResponse<bool>> UpdateGroup(Groups group);
    Task<ApiResponse<bool>> DeleteGroup(int groupId);
    Task<ApiResponse<Groups>> GetGroup(int groupId);
    Task<ApiResponse<List<Groups>>> GetGroups();
}
