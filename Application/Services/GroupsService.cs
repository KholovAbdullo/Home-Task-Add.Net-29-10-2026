using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class GroupsService(GroupsRepository groupsRepository) : IGroupsService
{
    private GroupsRepository groupsRepository1 = groupsRepository;
    public async Task AddGroup(Groups group)
    {
        var result=await groupsRepository1.AddGroup(group);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("Added nashud!");
    }

    public async Task DeleteGroup(int groupId)
    {
        var result=await groupsRepository1.DeleteGroup(groupId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public async Task GetAllGroup()
    {
        var result=await groupsRepository1.GetGroups();
        foreach (var g in result)
        {
            Console.WriteLine(g.GroupName+" "+g.CourseId+" "+g.MentorId+" "+g.StartDate+" "+g.EndDate);
        }
    }

    public async Task<List<Groups>> GetEmptyGroups()
    {
        var result = await groupsRepository1.GetEmptyGroups();
        return result;
    }


    public async Task GetGroup(int groupId)
    {
        var result = await groupsRepository1.GetGroup(groupId);
        Console.WriteLine(result.GroupName+" "+result.CourseId+" "+result.MentorId+" "+result.StartDate+" "+result.EndDate);

    }

    public async Task<List<Groups>> GetStudentsPerGroup()
    {
        var result=await groupsRepository1.GetStudentsPerGroup();
        return result;
    }

    public async Task UpdateGroup(Groups group)
    {
        var result = await groupsRepository1.UpdateGroup(group);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
