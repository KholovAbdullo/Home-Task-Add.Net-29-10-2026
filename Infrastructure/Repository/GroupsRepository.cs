using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GroupsRepository(Database database) : IGroupsRepository
{
    private Database database1 = database;
    public async Task<bool> AddGroup(Groups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Groups(name,course_id,mentor_id,startDate,EndDate) values(@name,@course_id,@mentor_id,@startDate,@EndDate)";
        var result = await conn.ExecuteAsync(query,group);
        return result>0;
    }

    public async Task<bool> DeleteGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Groups where id=@groupId";
        var result=await conn.ExecuteAsync(query,new{groupId});
        return result>0;
    }

    public Task<List<Groups>> GetEmptyGroups()
    {
        throw new NotImplementedException();
    }


    public async Task<Groups> GetGroup(int groupId)
    {
        using var con=database1.Connection();
        con.Open();
        var query="select * from Groups where id=@groupId";
        var result=await con.QuerySingleAsync<Groups>(query,new{groupId});
        return result;
    }

    public async Task<List<Groups>> GetGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Groups>("select * from Groups");
        return query.ToList();
    }

    public Task<List<StudentGroups>> GetStudentsPerGroup()
    {
        throw new NotImplementedException();
    }


    public async Task<bool> UpdateGroup(int id,Groups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update Groups set GroupName=@GroupName,course_id=@course_id,mentor_id=@mentor_id,startDate=@startDate,EndDate=@EndDate where id=@id";
        var result=await conn.ExecuteAsync(query,new {id,group.GroupName,group.CourseId,group.MentorId,group.StartDate,group.EndDate});
        return result>0;
    }

    Task<List<Groups>> IGroupsRepository.GetStudentsPerGroup()
    {
        throw new NotImplementedException();
    }
}
