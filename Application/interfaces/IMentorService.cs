using Domain.Models;

namespace Application.interfaces;

public interface IMentorService
{
    Task AddMentor(Mentors mentor);
    Task UpdateMentor(Mentors mentor);
    Task DeleteMentor(int mentorId);
    Task GetMentor(int mentorId);
    Task GetAllMentor();
}
