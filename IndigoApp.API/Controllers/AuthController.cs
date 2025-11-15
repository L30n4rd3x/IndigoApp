using IndigoApp.Domain.DTOs;
using IndigoApp.Domain.Interfaces;
using IndigoApp.Forms.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace IndigoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServ;
        public AuthController(IAuthService authService)
        {
            _authServ = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Domain.DTOs.LoginRequest request)
        {
            var (success, token, user) = await _authServ.LoginAsync(request.Username, request.Password);

            if (!success || user == null || !VerifyPassword(request.Password, user.Password))
            {
                return Unauthorized(new AuthResponse
                {
                    Success = false,
                    Message = "Usuario o contraseña incorrectos"
                });
            }

            return Ok(new AuthResponse
            {
                Success = true,
                Message = "Login exitoso",
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                RoleUser = user.RoleUser
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Domain.DTOs.RegisterRequest request)
        {
            var (success, message) = await _authServ.RegisterAsync(request.Username, HashPassword(request.Password), request.UserRole);

            if (!success)
            {
                return BadRequest(new AuthResponse
                {
                    Success = false,
                    Message = message
                });
            }

            return Ok(new AuthResponse
            {
                Success = true,
                Message = message
            });
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private static bool VerifyPassword(string password, string hash)
            => HashPassword(password) == hash;

    }
}
