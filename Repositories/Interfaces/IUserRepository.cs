using FastypeService.Models;

namespace FastypeService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(User user);
        Task<bool> IsEmailExistAsync(string email);
        Task<bool> IsUsernameExistAsync(string username);
    }
}
