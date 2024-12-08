using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.RepositoryAbstractions
{
    public interface IUsersRepository
    {
        Task<int> AddAsync(Users user);
        Task<string> CheckLoginPassword(string login, string password);
        Task<int> Delete(string login, string password);
    }
}
