using Application.DTOs.Groups;
using Application.interfaces;
using Application.Responses;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Catrollers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupsService groupsService) : ControllerBase
{
    private IGroupsService groupsService1 = groupsService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto group)
    {
        return await groupsService1.AddGroup(group);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id,UpdateGroupDto group)
    {
        return await groupsService1.UpdateGroup(id,group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int groupId)
    {
        return await groupsService1.DeleteGroup(groupId);
    }

    [HttpGet("{groupId:int}")]
    public async Task<ApiResponse<GroupDto>> GetGroup(int groupId)
    {
        return await groupsService1.GetGroup(groupId);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        return await groupsService1.GetGroups();
    }
}
