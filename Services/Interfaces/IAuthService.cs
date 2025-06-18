using FastypeService.Models.DTOs;

namespace FastypeService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<SignupResponseDto> SignupAsync(SignupDto signupDto);
    }
}
