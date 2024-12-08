using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface IUsersService
    {
        Task<int> AddUsersAsync(Users user);
        Task<string> CheckLoginPasswordUserAsync(string login, string password);
        Task<int> DeleteUserAsync(string login, string password);
    }

}
