using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstructions.RepositoryAbstructions
{
    public interface IStudentsRepository
    {
        Task<int> AddAsync(Students student);
        Task<int> DeleteAsync(int id);
        Task<List<Students>> GetAsync();
        Task<Students?> GetByLastNameAsync(string lastName);
        Task<int> UpdateAsync(Students student);
    }
}
