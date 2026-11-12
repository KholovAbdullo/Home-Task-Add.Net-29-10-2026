using System.Net;
using Application.DTOs.StudentGroups;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupsService(IStudentGroupsRepository studentGroupRepository) : IStudentGroupsService
{
    private IStudentGroupsRepository studentGroupRepository1 = studentGroupRepository;

    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto group)
    {
        var groups = new StudentGroups()
        {
            StudentId = group.StudentId,
            GroupId = group.GroupId,
            Status = group.Status
        };

        var res = await studentGroupRepository1.AddStudentGroup(groups);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }


    public async Task<ApiResponse<bool>> DeleteStudentGroup(int groupId)
    {
        var res = await studentGroupRepository1.DeleteStudentGroup(groupId);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", res);
    }

    public async Task<ApiResponse<StudentGroupDto>> GetStudentGroup(int groupId)
    {
        var res = await studentGroupRepository1.GetStudentGroup(groupId);
        if(res == null)
        {
            return new ApiResponse<StudentGroupDto>(HttpStatusCode.NotFound, "StudentGroup not found!", null!);
        }

        var group = new StudentGroupDto()
        {
            StudentGroupId = res.StudentGroupId,
            StudentId = res.StudentId,
            GroupId = res.GroupId,
            Status = res.Status
        };

        return new ApiResponse<StudentGroupDto>(HttpStatusCode.OK, "StudentGroup!",group);
    }

    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        var res = await studentGroupRepository1.GetStudentGroups();
        var group = res.Select(sg=>new StudentGroupDto
        {
            StudentGroupId = sg.StudentGroupId,
            StudentId = sg.StudentId,
            GroupId = sg.GroupId,
            Status = sg.Status
        }).ToList();

        return new ApiResponse<List<StudentGroupDto>>(HttpStatusCode.OK, "List StudentGroups!",group);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id, UpdateStudentGroupDto group)
    {
        var groups = new StudentGroups()
        {
            StudentId = group.StudentId,
            GroupId = group.GroupId,
            Status = group.Status
        };

        var res = await studentGroupRepository1.UpdateStudentGroup(id,groups);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }
}
