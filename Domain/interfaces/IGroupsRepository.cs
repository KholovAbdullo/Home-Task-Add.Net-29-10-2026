using Domain.Models;

namespace Domain.interfaces;

public interface IGroupsRepository
{
    Task<bool> AddGroup(Groups group);
    Task<bool> UpdateGroup(Groups group);
    Task<bool> DeleteGroup(int groupId);
    Task<Groups> GetGroup(int groupId);
    Task<List<Groups>> GetGroups();
    Task<List<Groups>> GetStudentsPerGroup();
    Task<List<Groups>> GetEmptyGroups();
}
