using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface ISubjectsService
    {
        Task<int> AddSubjectsAsync(Subjects subject);
        Task<int> DeleteSubjectAsync(int id);
        Task<List<Subjects>> GetAllSubjectsAsync();
        Task<Subjects?> GetSubjectsByNameAsync(string name);
        Task<int> UpdateSubjectAsync(Subjects subject);
    }
}
