using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface IGroupsService
    {
        Task<int> AddGroupAsync(Groups group);
        Task<int> DeleteGroupAsync(int id);
        Task<List<Groups>> GetAllGroupAsync();
        Task<Groups?> GetGroupByNameAsync(string name);
        Task<int> UpdateGroupAsync(Groups group);
    }
}
