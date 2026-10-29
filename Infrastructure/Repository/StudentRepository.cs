using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentRepository(Database database) : IStudentRepository
{
    private Database database1=database;
    public bool AddStudent(Students student)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Students(fullname,email,phone,EnrollmentDate) values(@fullname,@email,@phone,@EnrollmentDate)";
        var result=conn.Execute(query,student);
        return result>0;
    }

    public bool DeleteStudent(int studentId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Students where id=@studentId";
        var result=conn.Execute(query,new{studentId});
        return result>0;
    }

    public Students GetStudent(int studentId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students where id=@studentId";
        var result=conn.QuerySingle<Students>(query,new{studentId});
        return result;
    }

    public List<Students> GetStudents()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=conn.Query<Students>("select * from Students");
        return query.ToList();
    }

    public bool UpdateStudent(Students student)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update Students set fullname=@fullname,email=@email,phone=@phone,EnrollmentDate=@EnrollmentDate where id=@id";
        var result=conn.Execute(query,student);
        return result>0;
    }

}
