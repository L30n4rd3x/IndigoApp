using IndigoApp.Domain.Entities;
using IndigoApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Services
{
    public class AuthJWTServices : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthJWTServices(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? "MySecretKeyForJWTAuth2024SuperSecure!";
            var issuer = jwtSettings["Issuer"] ?? "AppIndigoAPI";
            var audience = jwtSettings["Audience"] ?? "AppIndigoClient";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.RoleUser)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<(bool Success, string Token, User? User)> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return (false, string.Empty, null);
            }

            // En producción, usar BCrypt o similar para hash de contraseñas
            if (user.Password != password)
            {
                return (false, string.Empty, null);
            }

            var token = GenerateJwtToken(user);
            return (true, token, user);
        }

        public async  Task<(bool Success, string Message)> RegisterAsync(string username, string password, string role = "user")
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);

            if (existingUser != null)
            {
                return (false, "El usuario ya existe");
            }

            var user = new User
            {
                Username = username,
                Password = password, // En producción, hashear la contraseña
                RoleUser = role,
            };

            await _userRepository.AddUserAsync(user);
            return (true, "Usuario registrado exitosamente");
        }
    }
}
