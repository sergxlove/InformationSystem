using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;


namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly InformationSystemDbContext _context;

        public GroupsRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Groups>> GetAsync()
        {
            var groupsEntity = await _context.Groups
                .AsNoTracking()
                .ToListAsync();
            return groupsEntity.Select(a => new Groups(a.Id, a.Name, a.Specialization)).ToList();
        }

        public async Task<Groups?> GetByNameAsync(string name)
        {
            var groupEntity = await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Name.Contains(name));
            if (groupEntity is not null)
            {
                return new Groups(groupEntity.Id, groupEntity.Name, groupEntity.Specialization);
            }
            return null;
        }

        public async Task<int> AddAsync(Groups groups)
        {
            GroupsEntity groupsEntity = new()
            {
                Id = groups.Id,
                Name = groups.Name,
                Specialization = groups.Specialization
            };
            await _context.Groups.AddAsync(groupsEntity);
            await _context.SaveChangesAsync();
            return groupsEntity.Id;
        }

        public async Task<int> UpdateAsync(Groups groups)
        {
            return await _context.Groups
                .Where(a => a.Id == groups.Id)
                .AsNoTracking()
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.Id, groups.Id)
                .SetProperty(a => a.Name, groups.Name)
                .SetProperty(a => a.Specialization, groups.Specialization));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Groups
                .Where(a => a.Id == id)
                .AsNoTracking()
                .ExecuteDeleteAsync();
        }
    }
}
