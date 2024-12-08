using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstructions.RepositoryAbstructions
{
    public interface IGroupsRepository
    {
        Task<int> AddAsync(Groups groups);
        Task<int> DeleteAsync(int id);
        Task<List<Groups>> GetAsync();
        Task<Groups?> GetByNameAsync(string name);
        Task<int> UpdateAsync(Groups groups);
    }
}
