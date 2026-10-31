using Domain.Models;

namespace Domain.interfaces;

public interface IMentorRepository
{
    Task<bool> AddMentor(Mentors mentor);
    Task<bool> UpdateMentor(Mentors mentor);
    Task<bool> DeleteMentor(int mentorId);
    Task<Mentors> GetMentors(int mentorId);
    Task<List<Mentors>> GetMentor();
    Task<Mentors> GetMentorWithMostStudents();
    Task<List<Mentors>> GetMentorsWithMultipleCourses();
}
