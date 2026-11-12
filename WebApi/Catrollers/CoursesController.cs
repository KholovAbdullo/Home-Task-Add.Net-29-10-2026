using Application.DTOs.Courses;
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
    public async Task<ApiResponse<bool>> AddCourses(CreateCourseDto courses)
    {
        return await course.AddCourses(courses);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourses(int id,UpdateCourseDto courses)
    {
        return await course.UpdateCourses(id,courses);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourses(int courseId)
    {
        return await course.DeleteCourses(courseId);
    }

    [HttpGet("{courseId:int}")]
    public Task<ApiResponse<CourseDto>> GetCourse(int courseId)
    {
        return course.GetCourse(courseId);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CourseDto>>> GetCourses()
    {
        return await course.GetCourses();
    }
}
