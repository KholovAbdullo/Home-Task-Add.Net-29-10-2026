using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class StudentGroupsService(StudentGroupRepository studentGroupRepository) : IStudentGroupsService
{
    private StudentGroupRepository studentGroupRepository1 = studentGroupRepository;
    public async Task AddStudentGroup(StudentGroups group)
    {
        var resul=await studentGroupRepository1.AddStudentGroup(group);
        if(resul)Console.WriteLine("Added successfully!");
        else Console.WriteLine("Added nashud!");
    }

    public async Task DeleteStudentGroup(int groupId)
    {
        var resul=await studentGroupRepository1.DeleteStudentGroup(groupId);
        if(resul)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public async Task GetAllStudentGroup()
    {
        var resul=await studentGroupRepository1.GetStudentGroups();
        foreach(var sg in resul)
        {
            Console.WriteLine(sg.StudentId+" "+sg.GroupId+" "+sg.Status);
        }
    }

    public async Task GetStudentGroup(int groupId)
    {
        var resul=await studentGroupRepository1.GetStudentGroup(groupId);
        Console.WriteLine(resul.StudentId+" "+resul.GroupId+" "+resul.Status);

    }

    public async Task UpdateStudentGroup(StudentGroups group)
    {
        var resul=await studentGroupRepository1.UpdateStudentGroup(group);
        if(resul)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
