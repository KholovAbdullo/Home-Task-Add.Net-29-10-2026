using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CourseRepository(Database database) : ICoursesRepository
{
    private Database database1 = database;
    public bool AddCourses(Courses courses)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Courses(title,description,durationWeeks) values(@title,@description,@durationWeeks)";
        var result=conn.Execute(query,courses);
        return result>0;
    }

    public bool DeleteCourses(int courseId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Courses where id=@courseId";
        var result=conn.Execute(query,new{courseId});
        return result>0;
    }

    public Courses GetCourse(int courseId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Courses where id=@courseId";
        var result=conn.QuerySingle<Courses>(query,new{courseId});
        return result;
    }

    public List<Courses> GetCourses()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=conn.Query<Courses>("select * from Courses");
        return query.ToList();
    }

    public bool UpdateCourses(Courses courses)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="Update Courses set title=@title,description=@description,durationWeeks=@durationWeeks where id=@id";
        var result=conn.Execute(query,courses);
        return result>0;
    }

}
