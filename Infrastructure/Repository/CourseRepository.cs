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

    public async Task<List<Courses>> GetLeastPopularCourses()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select c.id,c.title,count(sg.student_id) from Courses c left join Groups g on c.id=g.course_id left join StudentGroups sg on g.id=sg.group_id group by c.id,c.title order by count(sg.student_id) limit 3";
        var result = await conn.QueryAsync<Courses>(query);
        return result.ToList();
    }

    public async Task<Courses> GetMostPopularCourse()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select c.id,c.title,count(sg.student_id) from Courses c left join Groups g on c.id=g.course_id left join StudentGroups sg on g.id=sg.group_id group by c.id,c.title order by count(sg.student_id) desc limit 1";
        var result=await conn.QuerySingleAsync<Courses>(query);
        return result;
    }

    public async Task<List<Courses>> GetStudentsPerCourse()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select c.id,c.title,count(sg.student_id) from Courses c left join Groups g on c.id=g.course_id left join StudentGroups sg on g.id=sg.group_id group by c.id,c.title";
        var result=await conn.QueryAsync<Courses>(query);
        return result.ToList();
    }

    public async Task<List<Courses>> GetTopThreeCourses()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select c.id,c.title,count(sg.student_id) from Courses c left join Groups g on c.id=g.course_id left join StudentGroups sg on g.id=sg.group_id group by c.id,c.title order by count(sg.student_id) desc limit 3";
        var result = await conn.QueryAsync<Courses>(query);
        return result.ToList();
    }


    public async Task<bool> UpdateCourses(Courses courses)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="Update Courses set title=@title,description=@description,durationWeeks=@durationWeeks where id=@id";
        var result=await conn.ExecuteAsync(query,courses);
        return result>0;
    }

}
