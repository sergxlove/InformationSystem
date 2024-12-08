using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface IStudentsService
    {
        Task<int> AddStudentAsync(Students student);
        Task<int> DeleteStudentAsync(int id);
        Task<List<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentsByNameAsync(string name);
        Task<int> UpdateStudentAsync(Students student);
    }
}
