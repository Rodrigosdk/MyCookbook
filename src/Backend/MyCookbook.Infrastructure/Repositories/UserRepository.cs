using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Entities;
using MyCookbook.Domain.Repositories;
using MyCookbook.Infrastructure.Database;

namespace MyCookbook.Infrastructure.Repositories
{
    public class UserRepository(DataContext context) : IUsersRepository
    {
        private readonly DataContext _context = context;

        public async Task<bool> CheckEmailExists(string user)
        {
            return await _context.Users.AnyAsync(data => data.Email == user);
        }

        public async Task Create(UserEntity user)
        {
           await _context.Users.AddAsync(user);
        }
    }
}
