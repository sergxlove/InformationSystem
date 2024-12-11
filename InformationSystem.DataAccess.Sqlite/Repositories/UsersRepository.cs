using InformationSystem.Core.Abstractions.RepositoryAbstractions;
using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly InformationSystemDbContext _context;

        public UsersRepository(InformationSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Users user)
        {
            UsersEntity usersEntity = new()
            {
                //Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
            await _context.Users.AddAsync(usersEntity);
            await _context.SaveChangesAsync();
            return usersEntity.Id;
        }

        public async Task<Users?> CheckLoginPassword(string login, string password)
        {
            var users = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Login == login);
            if (users is not null)
            {
                if (users.Password != password)
                {
                    return null;
                }
                else
                {
                    return new Users(users.Id, users.Login, users.Password, users.Role);
                }
            }
            return null;
        }

        public async Task<int> Delete(string login, string password)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(a => a.Login == login)
                .ExecuteDeleteAsync();
        }
    }
}
