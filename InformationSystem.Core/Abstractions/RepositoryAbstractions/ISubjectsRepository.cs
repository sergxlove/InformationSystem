using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstructions.RepositoryAbstructions
{
    public interface ISubjectsRepository
    {
        Task<int> AddAsync(Subjects subject);
        Task<int> DeleteAsync(int id);
        Task<List<Subjects>> GetAsync();
        Task<Subjects?> GetByNameAsync(string name);
        Task<int> UpdateAsync(Subjects subject);
    }
}
