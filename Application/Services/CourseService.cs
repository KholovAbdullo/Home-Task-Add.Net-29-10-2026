using System.Net;
using Application.DTOs.Courses;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class CourseService(ICoursesRepository coursesRepository) : ICourseService
{
    private ICoursesRepository courseRepository1 = coursesRepository;

    public async Task<ApiResponse<bool>> AddCourses(CreateCourseDto courseDto)
    {
        var course = new Courses()
        {
            Title=courseDto.Title,
            Description=courseDto.Description,
            DurationWeeks=courseDto.DurationWeeks
        };

        var res = await courseRepository1.AddCourses(course);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }


    public async Task<ApiResponse<bool>> DeleteCourses(int courseId)
    {
        var res = await courseRepository1.DeleteCourses(courseId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<CourseDto>> GetCourse(int courseId)
    {
        var res = await courseRepository1.GetCourse(courseId);
        if (res == null)
        {
            return new ApiResponse<CourseDto>(HttpStatusCode.NotFound, "Course not found!",null!);
        }

        var course = new CourseDto()
        {
            Id=res.Id,
            Title=res.Title,
            Description=res.Description,
            DurationWeeks=res.DurationWeeks
        };

        return new ApiResponse<CourseDto>(HttpStatusCode.OK, "Courses!",course);
    }

    public async Task<ApiResponse<List<CourseDto>>> GetCourses()
    {
        var res = await courseRepository1.GetCourses();
        var course = res.Select(c=>new CourseDto
        {
            Id=c.Id,
            Title=c.Title,
            Description=c.Description,
            DurationWeeks=c.DurationWeeks
        }).ToList();

        return new ApiResponse<List<CourseDto>>(HttpStatusCode.OK, "List Courses!", course);
    }

    public async Task<ApiResponse<bool>> UpdateCourses(int id,UpdateCourseDto courseDto)
    {
        var course = new Courses()
        {
            Title=courseDto.Title,
            Description=courseDto.Description,
            DurationWeeks=courseDto.DurationWeeks
        };

        var res = await courseRepository1.UpdateCourses(id,course);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
