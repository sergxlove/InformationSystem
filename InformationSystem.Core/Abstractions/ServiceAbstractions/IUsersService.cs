using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface IUsersService
    {
        Task<int> AddUsersAsync(Users user);
        Task<Users?> CheckLoginPasswordUserAsync(string login, string password);
        Task<int> DeleteUserAsync(string login, string password);
    }

}
