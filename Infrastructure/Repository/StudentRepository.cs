using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentRepository(Database database) : IStudentRepository
{
    private Database database1=database;
    public async Task<bool> AddStudent(Students student)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Students(fullname,email,phone,EnrollmentDate) values(@fullname,@email,@phone,@EnrollmentDate)";
        var result=await conn.ExecuteAsync(query,student);
        return result>0;
    }

    public async Task<bool> DeleteStudent(int studentId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Students where id=@studentId";
        var result=await conn.ExecuteAsync(query,new{studentId});
        return result>0;
    }

    public async Task<List<Students>> GetDroppedOutStudents()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students s join StudentGroups sg on s.id=sg.student_id where sg.Status='Отчислен'";
        var result=await conn.QueryAsync<Students>(query);
        return result.ToList();
    }

    public async Task<List<Students>> GetGraduatedStudents()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students s join StudentGroups sg on s.id=sg.student_id where sg.Status='Завершил'";
        var result=await conn.QueryAsync<Students>(query);
        return result.ToList();
    }


    public async Task<Students> GetStudent(int studentId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students where id=@studentId";
        var result=await conn.QuerySingleAsync<Students>(query,new{studentId});
        return result;
    }

    public async Task<List<Students>> GetStudents()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Students>("select * from Students");
        return query.ToList();
    }

    public async Task<List<Students>> GetStudentsWithGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students s join StudentGroups sg on s.id=sg.student_id";
        var result=await conn.QueryAsync<Students>(query);
        return result.ToList();
    }

    public async Task<List<Students>> GetStudentsWithoutGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Students s left join StudentGroups sg on s.id=sg.student_id where sg.student_id is null";
        var result=await conn.QueryAsync<Students>(query);
        return result.ToList();
    }


    public async Task<bool> UpdateStudent(Students student)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update Students set fullname=@fullname,email=@email,phone=@phone,EnrollmentDate=@EnrollmentDate where id=@id";
        var result= await conn.ExecuteAsync(query,student);
        return result>0;
    }

}
