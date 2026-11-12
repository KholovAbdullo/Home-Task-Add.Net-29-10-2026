using System.Net;
using Application.DTOs.Students;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentServices
{
    private IStudentRepository studentRepository1 = studentRepository;

    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto)
    {
        var student = new Students()
        {
            Fullname = studentDto.Fullname,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            EnrollmentDate = studentDto.EnrollmentDate
        };

        var res = await studentRepository1.AddStudent(student);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }


    public async Task<ApiResponse<bool>> DeleteStudent(int studentId)
    {
        var res = await studentRepository1.DeleteStudent(studentId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<StudentDto>> GetStudent(int studentId)
    {
        var res = await studentRepository1.GetStudent(studentId);
        if (res == null)
        {
            return new ApiResponse<StudentDto>(HttpStatusCode.NotFound, "Student not faund!", null!);
        }

        var student = new StudentDto()
        {
            Id=res.Id,
            FullName=res.Fullname,
            Email=res.Email,
            Phone=res.Phone,
            EnrollmentDate=res.EnrollmentDate
        };

        return new ApiResponse<StudentDto>(HttpStatusCode.OK, "Student!", student);
    }

    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        var res = await studentRepository1.GetStudents();
        var student = res.Select(s=>new StudentDto
        {
            Id=s.Id,
            FullName=s.Fullname,
            Email=s.Email,
            Phone=s.Phone,
            EnrollmentDate=s.EnrollmentDate
        }).ToList();

        return new ApiResponse<List<StudentDto>>(HttpStatusCode.OK, "List Students!",student);
    }

    public async Task<ApiResponse<bool>> UpdateStudent(int id,UpdateStudentDto studentDto)
    {
        var student = new Students()
        {
            Fullname = studentDto.FullName,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            EnrollmentDate = studentDto.EnrollmentDate
        };

        var res = await studentRepository1.UpdateStudent(id,student);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
