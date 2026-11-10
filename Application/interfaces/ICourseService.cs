using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface ICourseService
{
    Task<ApiResponse<bool>> AddCourses(Courses courses);
    Task<ApiResponse<bool>> UpdateCourses(Courses courses);
    Task<ApiResponse<bool>> DeleteCourses(int courseId);
    Task<ApiResponse<Courses>> GetCourse(int courseId);
    Task<ApiResponse<List<Courses>>> GetCourses();
}
