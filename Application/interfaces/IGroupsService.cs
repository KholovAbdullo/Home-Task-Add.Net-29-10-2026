using Domain.Models;

namespace Application.interfaces;

public interface IGroupsService
{
    Task AddGroup(Groups group);
    Task UpdateGroup(Groups group);
    Task DeleteGroup(int groupId);
    Task GetGroup(int groupId);
    Task GetAllGroup();
}
