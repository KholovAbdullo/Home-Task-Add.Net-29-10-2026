using Application.interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Catrollers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(IMentorService mentorService) : ControllerBase
{
    private IMentorService mentorService1 = mentorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(Mentors mentor)
    {
        return await mentorService1.AddMentor(mentor);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMentor(Mentors mentor)
    {
        return await mentorService1.UpdateMentor(mentor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentor(int mentorId)
    {
        return await mentorService1.DeleteMentor(mentorId);
    }

    [HttpGet("{mentorId:int}")]
    public async Task<ApiResponse<Mentors>> GetMentors(int mentorId)
    {
        var res = await mentorService1.GetMentors(mentorId);

        if(res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Mentors>>> GetMentor()
    {
        return await mentorService1.GetMentor();
    }
}
