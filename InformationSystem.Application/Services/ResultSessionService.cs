using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class ResultSessionService
    {
        private readonly IResultSessionsRepository _repository;

        public ResultSessionService(IResultSessionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResultSession>> GetAllResultAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<int> AddResultAsync(ResultSession result)
        {
            return await _repository.AddAsync(result);
        }

        public async Task<int> UpdateResultAsync(ResultSession result)
        {
            return await _repository.UpdateAsync(result);
        }

        public async Task<int> DeleteResultAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
