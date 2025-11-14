using IndigoApp.Domain.DTOs;
using IndigoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

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

            if (!success || user == null)
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

    }
}
