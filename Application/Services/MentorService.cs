using System.Net;
using Application.DTOs.Mentors;
using Application.interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository mentorRepository1 = mentorRepository;

    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto)
    {
        var mentor = new Mentors()
        {
            Fullname = mentorDto.Fullname,
            Email = mentorDto.Email,
            Phone = mentorDto.Phone,
            Specialization = mentorDto.Specialization
        };

        var res = await mentorRepository1.AddMentor(mentor);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }


    public async Task<ApiResponse<bool>> DeleteMentor(int mentorId)
    {
        var res = await mentorRepository1.DeleteMentor(mentorId);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<List<MentorDto>>> GetMentor()
    {
        var res = await mentorRepository1.GetMentor();
        var mentor = res.Select(m=>new MentorDto
        {
            Id=m.Id,
            Fullname=m.Fullname,
            Email=m.Email,
            Phone=m.Phone,
            Specialization=m.Specialization  
        }).ToList();

        return new ApiResponse<List<MentorDto>>(HttpStatusCode.OK, "List Mentors!",mentor);
    }

    public async Task<ApiResponse<MentorDto>> GetMentors(int mentorId)
    {
        var res = await mentorRepository1.GetMentors(mentorId);
        if(res == null)
        {
            return new ApiResponse<MentorDto>(HttpStatusCode.NotFound, "Mentor not found!",null!);
        }

        var mentor = new MentorDto()
        {
            Id = res.Id,
            Fullname = res.Fullname,
            Email = res.Email,
            Phone = res.Phone,
            Specialization = res.Specialization
        };

        return new ApiResponse<MentorDto>(HttpStatusCode.OK, "Mentor!",mentor);
    }

    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto mentorDto)
    {
        var mentor = new Mentors()
        {
            Fullname = mentorDto.Fullname,
            Email = mentorDto.Email,
            Phone = mentorDto.Phone,
            Specialization = mentorDto.Specialization
        };

        var res = await mentorRepository1.UpdateMentor(id,mentor);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
