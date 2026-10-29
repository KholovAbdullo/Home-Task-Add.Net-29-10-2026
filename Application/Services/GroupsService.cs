using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class GroupsService(GroupsRepository groupsRepository) : IGroupsService
{
    private GroupsRepository groupsRepository1 = groupsRepository;
    public void AddGroup(Groups group)
    {
        var result=groupsRepository1.AddGroup(group);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("Added nashud!");
    }

    public void DeleteGroup(int groupId)
    {
        var result=groupsRepository1.DeleteGroup(groupId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public void GetAllGroup()
    {
        var result=groupsRepository1.GetGroups();
        foreach (var g in result)
        {
            Console.WriteLine(g.GroupName+" "+g.CourseId+" "+g.MentorId+" "+g.StartDate+" "+g.EndDate);
        }
    }

    public void GetGroup(int groupId)
    {
        var result = groupsRepository1.GetGroup(groupId);
        Console.WriteLine(result.GroupName+" "+result.CourseId+" "+result.MentorId+" "+result.StartDate+" "+result.EndDate);

    }

    public void UpdateGroup(Groups group)
    {
        var result = groupsRepository1.UpdateGroup(group);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
