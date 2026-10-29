using Domain.Models;

namespace Application.interfaces;

public interface IGroupsService
{
    void AddGroup(Groups group);
    void UpdateGroup(Groups group);
    void DeleteGroup(int groupId);
    void GetGroup(int groupId);
    void GetAllGroup();
}
