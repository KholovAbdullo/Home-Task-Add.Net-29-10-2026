using Application.interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Catrollers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    private ICourseService course = courseService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourses(Courses courses)
    {
        return await course.AddCourses(courses);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCourses(Courses courses)
    {
        return await course.UpdateCourses(courses);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourses(int courseId)
    {
        return await course.DeleteCourses(courseId);
    }

    [HttpGet("{courseId:int}")]
    public Task<ApiResponse<Courses>> GetCourse(int courseId)
    {
        var res = course.GetCourse(courseId);

        if(res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Courses>>> GetCourses()
    {
        return await course.GetCourses();
    }
}
