using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class SubjectsService
    {
        private readonly ISubjectsRepository _repository;

        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            _repository = subjectsRepository;
        }

        public async Task<List<Subjects>> GetAllSubjectsAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Subjects?> GetSubjectsByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<int> AddSubjectsAsync(Subjects subject)
        {
            return await _repository.AddAsync(subject);
        }

        public async Task<int> UpdateSubjectAsync(Subjects subject)
        {
            return await _repository.UpdateAsync(subject);
        }

        public async Task<int> DeleteSubjectAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
