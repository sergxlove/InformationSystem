using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class ResultSessionsRepository
    {
        private readonly InformationSystemDbContext _context;

        public ResultSessionsRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultSession>> Get()
        {
            var resultSessionEntity = await _context.ResultSessions
                .AsNoTracking()
                .ToListAsync();
            return resultSessionEntity.Select(a => new ResultSession(a.Id, a.IdSubject, a.IdStudent, a.Semestr,
                a.Grade, a.DateResult)).ToList();
        }

        public async Task<int> Add(ResultSession resultSession)
        {
            ResultSessionEntity resultSessionEntity = new()
            {
                Id = resultSession.Id,
                IdSubject = resultSession.IdSubject,
                IdStudent = resultSession.IdStudent,
                Semestr = resultSession.Semestr,
                Grade = resultSession.Grade,
                DateResult = resultSession.DateResult
            };
            await _context.ResultSessions.AddAsync(resultSessionEntity);
            await _context.SaveChangesAsync();
            return resultSessionEntity.Id;
        }

        public async Task<int> Update(ResultSession resultSession)
        {
            return await _context.ResultSessions
                .AsNoTracking()
                .Where(a => a.Id == resultSession.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(a =>  a.Id, resultSession.Id)
                .SetProperty(a => a.IdSubject, resultSession.IdSubject)
                .SetProperty(a => a.IdStudent, resultSession.IdStudent)
                .SetProperty(a => a.Semestr, resultSession.Semestr)
                .SetProperty(a => a.Grade, resultSession.Grade)
                .SetProperty(a => a.DateResult, resultSession.DateResult));
        }

        public async Task<int> Delete(int id)
        {
            return await _context.ResultSessions
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
