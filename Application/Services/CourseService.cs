using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private CourseRepository courseRepository1 = courseRepository;
    public async Task AddCourse(Courses course)
    {
        var result=await courseRepository1.AddCourses(course);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("Added nashud!");
    }

    public async Task DeleteCourse(int courseId)
    {
        var result=await courseRepository1.DeleteCourses(courseId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public async Task GetAllCourse()
    {
        var course=await courseRepository1.GetCourses();
        foreach (var c in course)
        {
            Console.WriteLine(c.Id+" "+c.Title+" "+c.Description+" "+c.DurationWeeks);
        }
    }

    public async Task GetCourse(int courseId)
    {
        var result=await courseRepository1.GetCourse(courseId);
        Console.WriteLine(result.Id+" "+result.Title+" "+result.Description+" "+result.DurationWeeks);
    }

    public async Task UpdateCourse(Courses course)
    {
        var result=await courseRepository1.UpdateCourses(course);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
