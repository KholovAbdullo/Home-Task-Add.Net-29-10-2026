using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentGroupRepository(Database database) : IStudentGroupsRepository
{
    private Database database1 = database;
    public async Task<bool> AddStudentGroup(StudentGroups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into StudentGroups(student_id,group_id,Status) values(@student_id,@group_id,@Status)";
        var result=await conn.ExecuteAsync(query,group);
        return result>0;
    }   

    public async Task<bool> DeleteStudentGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from StudentGroups where id=@groupId";
        var result=await conn.ExecuteAsync(query,new{groupId});
        return result>0;
    }

    public async Task<StudentGroups> GetStudentGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from StudentGroups where id=@groupId";
        var resul=await conn.QuerySingleAsync<StudentGroups>(query,new{groupId});
        return resul;
    }

    public async Task<List<StudentGroups>> GetStudentGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=await conn.QueryAsync<StudentGroups>("select * from StudentGroups");
        return query.ToList();
    }

    public async Task<bool> UpdateStudentGroup(StudentGroups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update StudentGroups set student_id=@student_id,group_id=@group_id,Status=@Status where id=@id";
        var resul=await conn.ExecuteAsync(query,group);
        return resul>0;
    }
}
