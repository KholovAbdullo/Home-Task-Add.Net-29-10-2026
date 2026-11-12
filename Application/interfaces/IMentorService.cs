using Application.DTOs.Mentors;
using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IMentorService
{
    Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto);
    Task<ApiResponse<bool>> UpdateMentor(int id,UpdateMentorDto mentorDto);
    Task<ApiResponse<bool>> DeleteMentor(int mentorId);
    Task<ApiResponse<MentorDto>> GetMentors(int mentorId);
    Task<ApiResponse<List<MentorDto>>> GetMentor();
}
