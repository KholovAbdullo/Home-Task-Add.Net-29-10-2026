using System.Net;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupsService(IStudentGroupsRepository studentGroupRepository) : IStudentGroupsService
{
    private IStudentGroupsRepository studentGroupRepository1 = studentGroupRepository;

    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroups group)
    {
        var res = await studentGroupRepository1.AddStudentGroup(group);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteStudentGroup(int groupId)
    {
        var res = await studentGroupRepository1.DeleteStudentGroup(groupId);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", res);
    }

    public async Task<ApiResponse<StudentGroups>> GetStudentGroup(int groupId)
    {
        var res = await studentGroupRepository1.GetStudentGroup(groupId);

        return res != null
        ? new ApiResponse<StudentGroups>(HttpStatusCode.OK, "Found!", res)
        : new ApiResponse<StudentGroups>(HttpStatusCode.NotFound, "Not Found!", res!);
    }

    public async Task<ApiResponse<List<StudentGroups>>> GetStudentGroups()
    {
        var res = await studentGroupRepository1.GetStudentGroups();

        return new ApiResponse<List<StudentGroups>>(HttpStatusCode.OK, "Success!", res);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroups group)
    {
        var res = await studentGroupRepository1.UpdateStudentGroup(group);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated!", res);
    }
}
