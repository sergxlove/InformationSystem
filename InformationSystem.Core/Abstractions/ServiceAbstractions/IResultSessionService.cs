using InformationSystem.Core.Models;

namespace InformationSystem.Core.Abstractions.ServiceAbstractions
{
    public interface IResultSessionService
    {
        Task<int> AddResultAsync(ResultSession result);
        Task<int> DeleteResultAsync(int id);
        Task<List<ResultSession>> GetAllResultAsync();
        Task<int> UpdateResultAsync(ResultSession result);
    }
}
