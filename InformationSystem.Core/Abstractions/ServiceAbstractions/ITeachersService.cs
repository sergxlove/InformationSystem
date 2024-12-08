using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface ITeachersService
    {
        Task<int> AddTeachersAsync(Teachers teacher);
        Task<int> DeleteTeacherAsync(int id);
        Task<List<Teachers>> GetAllTeachers();
        Task<Teachers?> GetTeachersByNameAsync(string name);
        Task<int> UpdateTeacherAsync(Teachers teacher);
    }
}
