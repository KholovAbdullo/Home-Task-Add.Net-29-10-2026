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
    public async Task<ApiResponse<bool>> AddGroup(Groups group)
    {
        return await groupsService1.AddGroup(group);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGroup(Groups group)
    {
        return await groupsService1.UpdateGroup(group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int groupId)
    {
        return await groupsService1.DeleteGroup(groupId);
    }

    [HttpGet("{groupId:int}")]
    public async Task<ApiResponse<Groups>> GetGroup(int groupId)
    {
        var res = await groupsService1.GetGroup(groupId);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Groups>>> GetGroups()
    {
        return await groupsService1.GetGroups();
    }
}
