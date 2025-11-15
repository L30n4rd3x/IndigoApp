using IndigoApp.Domain.DTOs;
using IndigoApp.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Sale>?> GetAllSalesAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<Sale>>("sales");
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _apiClient.GetAsync<Sale>($"sales/{id}");
        }

        public async Task<IEnumerable<Sale>?> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _apiClient.GetAsync<IEnumerable<Sale>>($"sales/bydate?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
        }

        public async Task<Sale?> CreateSaleAsync(CreateSaleRequest request)
        {
            return await _apiClient.PostAsync<CreateSaleRequest, Sale>("sales", request);
        }
    }
}