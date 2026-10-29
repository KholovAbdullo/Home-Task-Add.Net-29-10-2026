using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private MentorRepository mentorRepository1 = mentorRepository;
    public void AddMentor(Mentors mentor)
    {
       var result=mentorRepository1.AddMentor(mentor);
       if(result)Console.WriteLine("Added successfully!");
       else Console.WriteLine("Added nashud!");
    }

    public void DeleteMentor(int mentorId)
    {
        var result=mentorRepository1.DeleteMentor(mentorId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public void GetAllMentor()
    {
        var result = mentorRepository1.GetMentor();
        foreach (var m in result)
        {
            Console.WriteLine(m.Id+" "+m.Fullname+" "+m.Email+" "+m.Phone+" "+m.Specialization);
        }
    }

    public void GetMentor(int mentorId)
    {
        var mentor=mentorRepository1.GetMentors(mentorId);
        Console.WriteLine(mentor.Id+" "+mentor.Fullname+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);

    }

    public void UpdateMentor(Mentors mentor)
    {
        var result=mentorRepository1.UpdateMentor(mentor);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("Update nashud!");
    }

}
