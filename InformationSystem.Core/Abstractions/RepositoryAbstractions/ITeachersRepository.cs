using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstructions.RepositoryAbstructions
{
    public interface ITeachersRepository
    {
        Task<int> AddAsync(Teachers teacher);
        Task<int> DeleteAsync(int id);
        Task<List<Teachers>> GetAsync();
        Task<Teachers?> GetByNameAsync(string lastname);
        Task<int> UpdateAsync(Teachers teacher);
    }
}
