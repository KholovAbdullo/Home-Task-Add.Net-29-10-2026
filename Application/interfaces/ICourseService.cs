using Application.DTOs.Courses;
using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface ICourseService
{
    Task<ApiResponse<bool>> AddCourses(CreateCourseDto courseDto);
    Task<ApiResponse<bool>> UpdateCourses(int id,UpdateCourseDto courseDto);
    Task<ApiResponse<bool>> DeleteCourses(int courseId);
    Task<ApiResponse<CourseDto>> GetCourse(int courseId);
    Task<ApiResponse<List<CourseDto>>> GetCourses();
}
