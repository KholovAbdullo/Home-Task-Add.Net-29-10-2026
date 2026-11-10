using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IMentorService
{
    Task<ApiResponse<bool>> AddMentor(Mentors mentor);
    Task<ApiResponse<bool>> UpdateMentor(Mentors mentor);
    Task<ApiResponse<bool>> DeleteMentor(int mentorId);
    Task<ApiResponse<Mentors>> GetMentors(int mentorId);
    Task<ApiResponse<List<Mentors>>> GetMentor();
}
