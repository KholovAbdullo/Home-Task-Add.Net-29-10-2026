using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CourseRepository(Database database) : ICoursesRepository
{
    private Database database1 = database;
    public async Task<bool> AddCourses(Courses courses)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Courses(title,description,durationWeeks) values(@title,@description,@durationWeeks)";
        var result=await conn.ExecuteAsync(query,courses);
        return result>0;
    }

    public async Task<bool> DeleteCourses(int courseId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Courses where id=@courseId";
        var result=await conn.ExecuteAsync(query,new{courseId});
        return result>0;
    }

    public async Task<Courses> GetCourse(int courseId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Courses where id=@courseId";
        var result=await conn.QuerySingleAsync<Courses>(query,new{courseId});
        return result;
    }

    public async Task<List<Courses>> GetCourses()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Courses>("select * from Courses");
        return query.ToList();
    }

    public Task<List<Courses>> GetLeastPopularCourses()
    {
        throw new NotImplementedException();
    }

    public Task<Courses> GetMostPopularCourse()
    {
        throw new NotImplementedException();
    }

    public Task<List<Courses>> GetTopThreeCourses()
    {
        throw new NotImplementedException();
    }


    public async Task<bool> UpdateCourses(int id,Courses courses)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="Update Courses set title=@title,description=@description,durationWeeks=@durationWeeks where id=@id";
        var result=await conn.ExecuteAsync(query,new {id,courses.Title,courses.Description,courses.DurationWeeks});
        return result>0;
    }

    Task<List<Courses>> ICoursesRepository.GetStudentsPerCourse()
    {
        throw new NotImplementedException();
    }
}
