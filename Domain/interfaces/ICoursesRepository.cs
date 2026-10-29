using Domain.Models;

namespace Domain.interfaces;

public interface ICoursesRepository
{
    bool AddCourses(Courses courses);
    bool UpdateCourses(Courses courses);
    bool DeleteCourses(int courseId);
    Courses GetCourse(int courseId);
    List<Courses> GetCourses();
}
