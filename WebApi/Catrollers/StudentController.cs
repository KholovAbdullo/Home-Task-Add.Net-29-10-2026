using Application.DTOs.Students;
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
    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto)
    {
        return await studentServices1.AddStudent(studentDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id,UpdateStudentDto studentDto)
    {
        return await studentServices1.UpdateStudent(id,studentDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int studentId)
    {
        return await studentServices1.DeleteStudent(studentId);
    }

    [HttpGet("{studentId:int}")]
    public async Task<ApiResponse<StudentDto>> GetStudent(int studentId)
    {
        return await studentServices1.GetStudent(studentId);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        return await studentServices1.GetStudents();
    }
}
