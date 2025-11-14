
using IndigoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string Token, User? User)> LoginAsync(string username, string password);
        Task<(bool Success, string Message)> RegisterAsync(string username, string password, string role = "user");
        string GenerateJwtToken(User user);
    }
}
