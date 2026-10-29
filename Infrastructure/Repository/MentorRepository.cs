using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MentorRepository(Database database) : IMentorRepository
{
    private Database database1 = database;
    public bool AddMentor(Mentors mentor)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="insert into Mentors(fullname,email,phone,specialization) values(@fullname,@email,@phone,@specialization)";
        var result=conn.Execute(query,mentor);
        return result>0;
    }

    public bool DeleteMentor(int mentorId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Mentors where id=@mentorId";
        var result=conn.Execute(query,new{mentorId});
        return result>0;
    }

    public Mentors GetMentors(int mentorId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Mentors where id=@mentorId";
        var result=conn.QuerySingle<Mentors>(query,new{mentorId});
        return result;
    }

    public List<Mentors> GetMentor()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=conn.Query<Mentors>("select * from Mentors");
        return query.ToList();
    }

    public bool UpdateMentor(Mentors mentor)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="Update Mentors set fullname=@fullname,email=@email,phone=@phone,specialization=@specialization where id=@id";
        var result=conn.Execute(query,mentor);
        return result>0;
    }

}
