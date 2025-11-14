using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Forms.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpc;
        private static string? _authToken;
        private const string Url = "https://localhost:7187/api";

        public ApiClient()
        {
            _httpc = new HttpClient
            {
                BaseAddress = new Uri(Url)
            };
        }

        public void SetAuthToken(string token)
        {
            _authToken = token;
            _httpc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void ClearAuthToken()
        {
            _authToken = null;
            _httpc.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpc.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);

            }
            return default;
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpc.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(json);
            }
            return default;
        }

        public async Task<HttpResponseMessage?> PutAsync<T>(string endpoint, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpc.PutAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HttpResponseMessage>(json);
            }
            return default;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var response = await _httpc.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }
    }
}
