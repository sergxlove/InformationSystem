using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class SubjectsRepository
    {
        private readonly InformationSystemDbContext _context;

        public SubjectsRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subjects>> Get()
        {
            var subjectsEntity = await _context.Subjects
                .AsNoTracking()
                .ToListAsync();
            return subjectsEntity.Select(a => new Subjects(a.Id, a.Name, a.Description, a.IdTeacher)).ToList();
        }

        public async Task<Subjects?> GetByName(string name)
        {
            var subjectEntity = await _context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Name.Contains(name));
            if(subjectEntity is not null)
            {
                return new Subjects(subjectEntity.Id, subjectEntity.Name, subjectEntity.Description, subjectEntity.IdTeacher);
            }
            return null;
        }

        public async Task<int> Add(Subjects subject)
        {
            SubjectsEntity subjectsEntity = new()
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                IdTeacher = subject.IdTeacher
            };
            await _context.AddAsync(subjectsEntity);
            await _context.SaveChangesAsync();
            return subjectsEntity.Id;
        }

        public async Task<int> Update(Subjects subject)
        {
            return await _context.Subjects
                .AsNoTracking()
                .Where(a => a.Id == subject.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.Id, subject.Id)
                .SetProperty(a => a.Name, subject.Name)
                .SetProperty(a => a.Description, subject.Description)
                .SetProperty(a => a.IdTeacher, subject.IdTeacher));
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Subjects
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
