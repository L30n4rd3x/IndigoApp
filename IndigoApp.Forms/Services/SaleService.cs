using IndigoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Forms.Services
{
    public class SaleService
    {
        private readonly ApiClient _apiClient;

        public SaleService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Sale>?> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<Sale>>("sales");
        }

        public async Task<Sale?> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<Sale>($"sales/{id}");
        }

        public async Task<List<Sale>?> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _apiClient.GetAsync<List<Sale>>(
                $"sales/daterange?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
        }

        public async Task<bool> CreateAsync(Sale sale)
        {
            var response = await _apiClient.PostAsync<Sale, Sale>("sales", sale);
            return response != null;
        }

    }
}
