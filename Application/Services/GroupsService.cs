using System.Net;
using Application.DTOs.Groups;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class GroupsService(IGroupsRepository groupsRepository) : IGroupsService
{
    private IGroupsRepository groupsRepository1 = groupsRepository;

    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto)
    {
        var group = new Groups()
        {
            GroupName = groupDto.GroupName,
            CourseId = groupDto.CourseId,
            MentorId = groupDto.MentorId,
            StartDate = groupDto.StartDate,
            EndDate = groupDto.EndDate
        };

        var res = await groupsRepository1.AddGroup(group);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }


    public async Task<ApiResponse<bool>> DeleteGroup(int groupId)
    {
        var res = await groupsRepository1.DeleteGroup(groupId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<GroupDto>> GetGroup(int groupId)
    {
        var res = await groupsRepository1.GetGroup(groupId);
        if(res == null)
        {
            return new ApiResponse<GroupDto>(HttpStatusCode.NotFound, "Groups not found!",null!);
        }

        var group = new GroupDto()
        {
            Id = res.Id,
            GroupName = res.GroupName,
            CourseId = res.CourseId,
            MentorId = res.MentorId,
            StartDate = res.StartDate,
            EndDate = res. EndDate
        };

        return new ApiResponse<GroupDto>(HttpStatusCode.OK, "Group!",group);
    }

    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        var res = await groupsRepository1.GetGroups();
        var group = res.Select(g=>new GroupDto
        {
            Id = g.Id,
            GroupName = g.GroupName,
            CourseId = g.CourseId,
            MentorId = g.MentorId,
            StartDate = g.StartDate,
            EndDate = g.EndDate
        }).ToList();

        return new ApiResponse<List<GroupDto>>(HttpStatusCode.OK, "List Group!",group);
    }

    public async Task<ApiResponse<bool>> UpdateGroup(int id,UpdateGroupDto groupDto)
    {
        var group = new Groups()
        {
            GroupName = groupDto.GroupName,
            CourseId = groupDto.CourseId,
            MentorId = groupDto.MentorId,
            StartDate = groupDto.StartDate,
            EndDate = groupDto.EndDate
        };

        var res = await groupsRepository1.UpdateGroup(id,group);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
