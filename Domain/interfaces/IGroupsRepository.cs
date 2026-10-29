using Domain.Models;

namespace Domain.interfaces;

public interface IGroupsRepository
{
    bool AddGroup(Groups group);
    bool UpdateGroup(Groups group);
    bool DeleteGroup(int groupId);
    Groups GetGroup(int groupId);
    List<Groups> GetGroups();
}
