using Domain.Models;

namespace Application.interfaces;

public interface ICourseService
{
    Task AddCourse(Courses course);
    Task UpdateCourse(Courses course);
    Task DeleteCourse(int courseId);
    Task GetCourse(int courseId);
    Task GetAllCourse();
}
