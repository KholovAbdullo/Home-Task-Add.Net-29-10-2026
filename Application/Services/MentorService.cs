using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private MentorRepository mentorRepository1 = mentorRepository;
    public async Task AddMentor(Mentors mentor)
    {
       var result=await mentorRepository1.AddMentor(mentor);
       if(result)Console.WriteLine("Added successfully!");
       else Console.WriteLine("Added nashud!");
    }

    public async Task DeleteMentor(int mentorId)
    {
        var result=await mentorRepository1.DeleteMentor(mentorId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public async Task GetAllMentor()
    {
        var result =await mentorRepository1.GetMentor();
        foreach (var m in result)
        {
            Console.WriteLine(m.Id+" "+m.Fullname+" "+m.Email+" "+m.Phone+" "+m.Specialization);
        }
    }

    public async Task GetMentor(int mentorId)
    {
        var mentor=await mentorRepository1.GetMentors(mentorId);
        Console.WriteLine(mentor.Id+" "+mentor.Fullname+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);

    }

    public async Task<List<Mentors>> GetMentorsWithMultipleCourses()
    {
        var result = await mentorRepository1.GetMentorsWithMultipleCourses();
        return result;
    }

    public async Task<Mentors> GetMentorWithMostStudents()
    {
        var result=await mentorRepository1.GetMentorWithMostStudents();
        return result;
    }


    public async Task UpdateMentor(Mentors mentor)
    {
        var result=await mentorRepository1.UpdateMentor(mentor);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
