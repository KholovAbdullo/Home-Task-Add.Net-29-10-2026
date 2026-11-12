using Application.DTOs.StudentGroups;
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
    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto group)
    {
        return await studentGroupsService1.AddStudentGroup(group);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id,UpdateStudentGroupDto group)
    {
        return await studentGroupsService1.UpdateStudentGroup(id,group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int groupId)
    {
        return await studentGroupsService1.DeleteStudentGroup(groupId);
    }

    [HttpGet("{groupId:int}")]
    public async Task<ApiResponse<StudentGroupDto>> GetStudentGroup(int groupId)
    {
        return await studentGroupsService1.GetStudentGroup(groupId);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        return await studentGroupsService1.GetStudentGroups();
    }
}
