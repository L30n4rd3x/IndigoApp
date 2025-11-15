using IndigoApp.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Forms.Services
{
    public class AuthService
    {
        private readonly ApiClient _apiClient;
        private static AuthResponse? _currentUser;

        public AuthService()
        {
            _apiClient = new ApiClient();
        }

        public static AuthResponse? CurrentUser => _currentUser;
        public static bool IsAuthenticated => _currentUser != null && !string.IsNullOrEmpty(_currentUser.Token);
        public static bool IsAdmin => _currentUser?.RoleUser == "admin";

        public async Task<AuthResponse?> LoginAsync(string username, string pass)
        {
            var logindata = new { Username = username, Password = HashPassword(pass) };
            var response = await _apiClient.PostAsync<object, AuthResponse>("auth/login", logindata);
            if (response != null && !string.IsNullOrEmpty(response.Token))
            {
                _currentUser = response;
                _apiClient.SetAuthToken(response.Token);
            }
            return response;
        }

        public async Task<AuthResponse?> RegisterAsync(string username, string pass, string role = "user")
        {
            var regdata = new { Username = username, Password = pass, RoleUser = role };
            var response = await _apiClient.PostAsync<object, AuthResponse>("auth/register", regdata);
            return response;
        }

        public void Logout()
        {
            _currentUser = null;
            _apiClient.ClearAuthToken();
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private static bool VerifyPassword(string password, string hash)
            => HashPassword(password) == hash;

        public ApiClient GetApiClient() => _apiClient;
    }
}
