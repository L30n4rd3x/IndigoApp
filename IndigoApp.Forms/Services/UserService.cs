using IndigoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Forms.Services
{
    public class UserService
    {
        private readonly ApiClient _apiClient;

        public UserService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<User>($"users/{id}");
        }

        public async Task<User?> GetByUsernameAsync(string user)
        {
            return await _apiClient.GetAsync<User>($"users/{user}");
        }

        public async Task<bool> CreateAsync(User user)
        {
            var response = await _apiClient.PostAsync<User, User>("users", user);
            return response != null;
        }

    }
}
