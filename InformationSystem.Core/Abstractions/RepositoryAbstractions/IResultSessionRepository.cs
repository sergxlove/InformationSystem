using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstructions.RepositoryAbstructions
{
    public interface IResultSessionsRepository
    {
        Task<int> AddAsync(ResultSession resultSession);
        Task<int> DeleteAsync(int id);
        Task<List<ResultSession>> GetAsync();
        Task<int> UpdateAsync(ResultSession resultSession);
    }
}
