using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private CourseRepository courseRepository1 = courseRepository;
    public void AddCourse(Courses course)
    {
        var result=courseRepository1.AddCourses(course);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("Added nashud!");
    }

    public void DeleteCourse(int courseId)
    {
        var result=courseRepository1.DeleteCourses(courseId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public void GetAllCourse()
    {
        var course=courseRepository1.GetCourses();
        foreach (var c in course)
        {
            Console.WriteLine(c.Id+" "+c.Title+" "+c.Description+" "+c.DurationWeeks);
        }
    }

    public void GetCourse(int courseId)
    {
        var result=courseRepository1.GetCourse(courseId);
        Console.WriteLine(result.Id+" "+result.Title+" "+result.Description+" "+result.DurationWeeks);
    }

    public void UpdateCourse(Courses course)
    {
        var result=courseRepository1.UpdateCourses(course);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
