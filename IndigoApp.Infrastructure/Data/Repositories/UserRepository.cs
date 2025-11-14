using IndigoApp.Domain.Entities;
using IndigoApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IndigoAppDbContext _ctx;

        public UserRepository(IndigoAppDbContext context)
        {
            _ctx = context;
        }
        public async Task AddUserAsync(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _ctx.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id) => await _ctx.Users.FindAsync(id);

        public async Task<User?> GetUserByUsernameAsync(string username) => await _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
