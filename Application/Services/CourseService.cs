using System.Net;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class CourseService(ICoursesRepository coursesRepository) : ICourseService
{
    private ICoursesRepository courseRepository1 = coursesRepository;

    public async Task<ApiResponse<bool>> AddCourses(Courses courses)
    {
        var res = await courseRepository1.AddCourses(courses);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteCourses(int courseId)
    {
        var res = await courseRepository1.DeleteCourses(courseId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<Courses>> GetCourse(int courseId)
    {
        var res = await courseRepository1.GetCourse(courseId);
        return res != null
        ? new ApiResponse<Courses>(HttpStatusCode.OK, "GetCourse id!",res)
        : new ApiResponse<Courses>(HttpStatusCode.NotFound, "Not GetCourse id!",res!);
    }

    public async Task<ApiResponse<List<Courses>>> GetCourses()
    {
        var res = await courseRepository1.GetCourses();
        return new ApiResponse<List<Courses>>(HttpStatusCode.OK, "ListCourses!",res);
    }

    public async Task<ApiResponse<bool>> UpdateCourses(Courses courses)
    {
        var res = await courseRepository1.UpdateCourses(courses);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!",res);
    }
}
