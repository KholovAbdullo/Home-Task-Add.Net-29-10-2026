using Domain.Models;

namespace Application.interfaces;

public interface ICourseService
{
    Task AddCourse(Courses course);
    Task UpdateCourse(Courses course);
    Task DeleteCourse(int courseId);
    Task GetCourse(int courseId);
    Task GetAllCourse();
    Task<List<Courses>> GetStudentsPerCourse();
    Task<Courses> GetMostPopularCourse();
    Task<List<Courses>> GetLeastPopularCourses();
    Task<List<Courses>> GetTopThreeCourses();
}
