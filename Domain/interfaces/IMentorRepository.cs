using Domain.Models;

namespace Domain.interfaces;

public interface IMentorRepository
{
    bool AddMentor(Mentors mentor);
    bool UpdateMentor(Mentors mentor);
    bool DeleteMentor(int mentorId);
    Mentors GetMentors(int mentorId);
    List<Mentors> GetMentor();
}
