using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly InformationSystemDbContext _context;

        public StudentsRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Students>> GetAsync()
        {
            var studentsEntity = await _context.Students
                .AsNoTracking()
                .ToListAsync();
            return studentsEntity.Select(a => new Students(a.Id, a.FirstName, a.SecondName, a.LastName,
                a.DateOfBirth, a.Email, a.IdGroup)).ToList();
        }

        public async Task<Students?> GetByLastNameAsync(string lastName)
        {
            var studentEntity = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.LastName.Contains(lastName));
            if (studentEntity is not null)
            {
                return new Students(studentEntity.Id, studentEntity.FirstName, studentEntity.SecondName,
                    studentEntity.LastName, studentEntity.DateOfBirth, studentEntity.Email, studentEntity.IdGroup);
            }
            return null;
        }

        public async Task<int> AddAsync(Students student)
        {
            StudentsEntity studentsEntity = new()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                IdGroup = student.IdGroup
            };
            await _context.AddAsync(studentsEntity);
            await _context.SaveChangesAsync();
            return studentsEntity.Id;
        }

        public async Task<int> UpdateAsync(Students student)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(a => a.Id == student.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.Id, student.Id)
                .SetProperty(a => a.FirstName, student.FirstName)
                .SetProperty(a => a.SecondName, student.SecondName)
                .SetProperty(a => a.LastName, student.LastName)
                .SetProperty(a => a.DateOfBirth, student.DateOfBirth)
                .SetProperty(a => a.Email, student.Email)
                .SetProperty(a => a.IdGroup, student.IdGroup));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
