using Application.interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Catrollers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentServices studentServices) : ControllerBase
{
    private IStudentServices studentServices1 = studentServices;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(Students student)
    {
        return await studentServices1.AddStudent(student);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudent(Students student)
    {
        return await studentServices1.UpdateStudent(student);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int studentId)
    {
        return await studentServices1.DeleteStudent(studentId);
    }

    [HttpGet("{studentId:int}")]
    public async Task<ApiResponse<Students>> GetStudent(int studentId)
    {
        var res = await studentServices1.GetStudent(studentId);

        if(res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Students>>> GetStudents()
    {
        return await studentServices1.GetStudents();
    }
}
