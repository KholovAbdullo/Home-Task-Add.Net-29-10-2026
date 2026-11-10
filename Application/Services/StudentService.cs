using System.Net;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentServices
{
    private IStudentRepository studentRepository1 = studentRepository;
    public async Task<ApiResponse<bool>> AddStudent(Students student)
    {
        var res = await studentRepository1.AddStudent(student);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteStudent(int studentId)
    {
        var res = await studentRepository1.DeleteStudent(studentId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<Students>> GetStudent(int studentId)
    {
        var res = await studentRepository1.GetStudent(studentId);
        return res !=null
        ? new ApiResponse<Students>(HttpStatusCode.OK, "GetStudent!", res)
        : new ApiResponse<Students>(HttpStatusCode.NotFound, "Not GetStudent!", res!);
    }

    public async Task<ApiResponse<List<Students>>> GetStudents()
    {
        var res = await studentRepository1.GetStudents();
        return new ApiResponse<List<Students>>(HttpStatusCode.OK, "GetStudents!", res);
    }

    public async Task<ApiResponse<bool>> UpdateStudent(Students student)
    {
        var res = await studentRepository1.UpdateStudent(student);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!", res);
    }
}
