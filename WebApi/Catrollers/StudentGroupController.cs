using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Catrollers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupsService studentGroupsService) : ControllerBase
{
    private IStudentGroupsService studentGroupsService1 = studentGroupsService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroups group)
    {
        return await studentGroupsService1.AddStudentGroup(group);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroups group)
    {
        return await studentGroupsService1.UpdateStudentGroup(group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int groupId)
    {
        return await studentGroupsService1.DeleteStudentGroup(groupId);
    }

    [HttpGet("{groupId:int}")]
    public async Task<ApiResponse<StudentGroups>> GetStudentGroup(int groupId)
    {
        var res = await studentGroupsService1.GetStudentGroup(groupId);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroups>>> GetStudentGroups()
    {
        return await studentGroupsService1.GetStudentGroups();
    }
}
