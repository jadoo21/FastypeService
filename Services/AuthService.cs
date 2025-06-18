using FastypeService.Models.DTOs;
using FastypeService.Models;
using FastypeService.Repositories.Interfaces;
using FastypeService.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FastypeService.Services
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<SignupResponseDto> SignupAsync(SignupDto signupDto)
        {
            var validationErrors = await ValidateSignup(signupDto);
            if (validationErrors.Any())
            {
                return new()
                {
                    Success = false,
                    Message = validationErrors
                }; 
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(signupDto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = signupDto.Username,
                Email = signupDto.Email,
                Password = hashedPassword,
                CreatedAt = DateTime.UtcNow
            };

            var userId = await userRepository.AddUserAsync(user);
            return new()
            {
                Id = userId,
                Success = true,
                Message = ["User registered successfully!!"]
            };
        }

        private async Task<List<string>> ValidateSignup(SignupDto signupDto)
        {
            var errors = new List<string>();

            if (await userRepository.IsEmailExistAsync(signupDto.Email))
            {
                errors.Add("Email Id already exists.");
            }

            if (await userRepository.IsUsernameExistAsync(signupDto.Username))
            {
                errors.Add("Username already exists.");
            }

            return errors;
        }
    }
}
