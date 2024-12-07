using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class TeachersService
    {
        private readonly ITeachersRepository _repository;

        public TeachersService(ITeachersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Teachers>> GetAllTeachers()
        {
            return await _repository.GetAsync();
        }

        public async Task<Teachers?> GetTeachersByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<int> AddTeachersAsync(Teachers teacher)
        {
            return await _repository.AddAsync(teacher);
        }

        public async Task<int> UpdateTeacherAsync(Teachers teacher)
        {
            return await _repository.UpdateAsync(teacher);
        }

        public async Task<int> DeleteTeacherAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
