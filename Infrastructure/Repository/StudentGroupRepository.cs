using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentGroupRepository(Database database) : IStudentGroupsRepository
{
    private Database database1 = database;
    public bool AddStudentGroup(StudentGroups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into StudentGroups(student_id,group_id,Status) values(@student_id,@group_id,@Status)";
        var result=conn.Execute(query,group);
        return result>0;
    }   

    public bool DeleteStudentGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from StudentGroups where id=@groupId";
        var result=conn.Execute(query,new{groupId});
        return result>0;
    }

    public StudentGroups GetStudentGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from StudentGroups where id=@groupId";
        var resul=conn.QuerySingle<StudentGroups>(query,new{groupId});
        return resul;
    }

    public List<StudentGroups> GetStudentGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=conn.Query<StudentGroups>("select * from StudentGroups");
        return query.ToList();
    }

    public bool UpdateStudentGroup(StudentGroups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update StudentGroups set student_id=@student_id,group_id=@group_id,Status=@Status where id=@id";
        var resul=conn.Execute(query,group);
        return resul>0;
    }
}
