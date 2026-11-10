using System.Net;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class GroupsService(IGroupsRepository groupsRepository) : IGroupsService
{
    private IGroupsRepository groupsRepository1 = groupsRepository;

    public async Task<ApiResponse<bool>> AddGroup(Groups group)
    {
        var res = await groupsRepository1.AddGroup(group);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteGroup(int groupId)
    {
        var res = await groupsRepository1.DeleteGroup(groupId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<Groups>> GetGroup(int groupId)
    {
        var res = await groupsRepository1.GetGroup(groupId);
        return res != null
        ? new ApiResponse<Groups>(HttpStatusCode.OK, "GetGroup id",res)
        : new ApiResponse<Groups>(HttpStatusCode.NotFound, "Not GetGroup id!", res!);
    }

    public async Task<ApiResponse<List<Groups>>> GetGroups()
    {
        var res = await groupsRepository1.GetGroups();
        return new ApiResponse<List<Groups>>(HttpStatusCode.OK, "ListGroup",res);
    }

    public async Task<ApiResponse<bool>> UpdateGroup(Groups group)
    {
        var res = await groupsRepository1.UpdateGroup(group);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!", res);
    }

}
