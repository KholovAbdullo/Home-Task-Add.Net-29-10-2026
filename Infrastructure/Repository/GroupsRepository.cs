using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GroupsRepository(Database database) : IGroupsRepository
{
    private Database database1 = database;
    public bool AddGroup(Groups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Groups(name,course_id,mentor_id,startDate,EndDate) values(@name,@course_id,@mentor_id,@startDate,@EndDate)";
        var result = conn.Execute(query,group);
        return result>0;
    }

    public bool DeleteGroup(int groupId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Groups where id=@groupId";
        var result=conn.Execute(query,new{groupId});
        return result>0;
    }

    public Groups GetGroup(int groupId)
    {
        using var con=database1.Connection();
        con.Open();
        var query="select * from Groups where id=@groupId";
        var result=con.QuerySingle<Groups>(query,new{groupId});
        return result;
    }

    public List<Groups> GetGroups()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=conn.Query<Groups>("select * from Groups");
        return query.ToList();
    }

    public bool UpdateGroup(Groups group)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="update Groups set GroupName=@GroupName,course_id=@course_id,mentor_id=@mentor_id,startDate=@startDate,EndDate=@EndDate where id=@id";
        var result=conn.Execute(query,group);
        return result>0;
    }

}
