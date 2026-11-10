using System.Net;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository mentorRepository1 = mentorRepository;

    public async Task<ApiResponse<bool>> AddMentor(Mentors mentor)
    {
        var res = await mentorRepository1.AddMentor(mentor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteMentor(int mentorId)
    {
        var res = await mentorRepository1.DeleteMentor(mentorId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<List<Mentors>>> GetMentor()
    {
        var res = await mentorRepository1.GetMentor();
        return new ApiResponse<List<Mentors>>(HttpStatusCode.OK, "GetMentor!",res);
    }

    public async Task<ApiResponse<Mentors>> GetMentors(int mentorId)
    {
        var res = await mentorRepository1.GetMentors(mentorId);
        return res != null
        ? new ApiResponse<Mentors>(HttpStatusCode.OK, "GetMentor id!",res)
        : new ApiResponse<Mentors>(HttpStatusCode.NotFound, "Not GenMentor id!",res!);
    }

    public async Task<ApiResponse<bool>> UpdateMentor(Mentors mentor)
    {
        var res = await mentorRepository1.UpdateMentor(mentor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!",res);
    }

}
