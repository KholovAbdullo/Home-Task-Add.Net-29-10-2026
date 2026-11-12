using Application.DTOs.Mentors;
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
    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentor)
    {
        return await mentorService1.AddMentor(mentor);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id,UpdateMentorDto mentor)
    {
        return await mentorService1.UpdateMentor(id,mentor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentor(int mentorId)
    {
        return await mentorService1.DeleteMentor(mentorId);
    }

    [HttpGet("{mentorId:int}")]
    public async Task<ApiResponse<MentorDto>> GetMentors(int mentorId)
    {
        return await mentorService1.GetMentors(mentorId);
    }

    [HttpGet]
    public async Task<ApiResponse<List<MentorDto>>> GetMentor()
    {
        return await mentorService1.GetMentor();
    }
}
