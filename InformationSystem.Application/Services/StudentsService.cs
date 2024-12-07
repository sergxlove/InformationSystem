using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;

namespace InformationSystem.Application.Services
{
    public class StudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public async Task<List<Students>> GetAllStudentsAsync()
        {
            return await _studentsRepository.GetAsync();
        }

        public async Task<Students?> GetStudentsByNameAsync(string name)
        {
            return await _studentsRepository.GetByLastNameAsync(name);
        }

        public async Task<int> AddStudentAsync(Students student)
        {
            return await _studentsRepository.AddAsync(student);
        }

        public async Task<int> UpdateStudentAsync(Students student)
        {
            return await _studentsRepository.UpdateAsync(student);
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _studentsRepository.DeleteAsync(id);
        }
    }
}
