using InformationSystem.Core.Abstractions.ServiceAbstractions;
using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsRepository _repository;

        public GroupsService(IGroupsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Groups>> GetAllGroupAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Groups?> GetGroupByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<int> AddGroupAsync(Groups group)
        {
            return await _repository.AddAsync(group);
        }

        public async Task<int> UpdateGroupAsync(Groups group)
        {
            return await _repository.UpdateAsync(group);
        }

        public async Task<int> DeleteGroupAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
