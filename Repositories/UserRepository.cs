using FastypeService.Data;
using FastypeService.Models;
using FastypeService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastypeService.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<Guid> AddUserAsync(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            return await context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
