using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly InformationSystemDbContext _context;

        public TeachersRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teachers>> GetAsync()
        {
            var teachersEntity = await _context.Teachers
                .AsNoTracking()
                .ToListAsync();
            return teachersEntity.Select(a => new Teachers(a.Id, a.FirstName, a.SecondName, a.LastName,
                a.DateOfBirth, a.Email, a.Departament)).ToList();
        }

        public async Task<Teachers?> GetByNameAsync(string lastname)
        {
            var teacherEntity = await _context.Teachers
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.LastName.Contains(lastname));
            if (teacherEntity is not null)
            {
                return new Teachers(teacherEntity.Id, teacherEntity.FirstName, teacherEntity.SecondName, teacherEntity.LastName,
                    teacherEntity.DateOfBirth, teacherEntity.Email, teacherEntity.Departament);
            }
            return null;
        }

        public async Task<int> AddAsync(Teachers teacher)
        {
            TeachersEntity teachersEntity = new()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                SecondName = teacher.SecondName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                Email = teacher.Email,
                Departament = teacher.Departament
            };
            await _context.AddAsync(teachersEntity);
            await _context.SaveChangesAsync();
            return teachersEntity.Id;
        }

        public async Task<int> UpdateAsync(Teachers teacher)
        {
            return await _context.Teachers
                .AsNoTracking()
                .Where(a => a.Id == teacher.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.Id, teacher.Id)
                .SetProperty(a => a.FirstName, teacher.FirstName)
                .SetProperty(a => a.SecondName, teacher.SecondName)
                .SetProperty(a => a.LastName, teacher.LastName)
                .SetProperty(a => a.DateOfBirth, teacher.DateOfBirth)
                .SetProperty(a => a.Email, teacher.Email)
                .SetProperty(a => a.Departament, teacher.Departament));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Teachers
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
