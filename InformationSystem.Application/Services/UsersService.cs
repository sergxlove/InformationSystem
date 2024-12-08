using InformationSystem.Core.Abstractions.RepositoryAbstractions;
using InformationSystem.Core.Abstractions.ServiceAbstractions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddUsersAsync(Users user)
        {
            return await _repository.AddAsync(user);
        }

        public async Task<string> CheckLoginPasswordUserAsync(string login, string password)
        {
            return await _repository.CheckLoginPassword(login, password);
        }

        public async Task<int> DeleteUserAsync(string login, string password)
        {
            return await _repository.Delete(login, password);
        }
    }
}
