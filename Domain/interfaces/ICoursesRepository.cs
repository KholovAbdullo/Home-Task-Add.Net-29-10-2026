using Domain.Models;

namespace Domain.interfaces;

public interface ICoursesRepository
{
    Task<bool> AddCourses(Courses courses);
    Task<bool> UpdateCourses(Courses courses);
    Task<bool> DeleteCourses(int courseId);
    Task<Courses> GetCourse(int courseId);
    Task<List<Courses>> GetCourses();
}
