using Application.DTOs.Groups;
using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IGroupsService
{
    Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto);
    Task<ApiResponse<bool>> UpdateGroup(int id,UpdateGroupDto groupDto);
    Task<ApiResponse<bool>> DeleteGroup(int groupId);
    Task<ApiResponse<GroupDto>> GetGroup(int groupId);
    Task<ApiResponse<List<GroupDto>>> GetGroups();
}
