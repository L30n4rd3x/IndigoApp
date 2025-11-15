using IndigoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Forms.Services
{
    public class ProductService
    {
        private readonly ApiClient _apiClient;
        public ProductService(ApiClient api) 
        {
            _apiClient = api;
        }

        public Task<IEnumerable<Product>?> GetAllProductsAsync()
        {
            return _apiClient.GetAsync<IEnumerable<Product>>("products");
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            return _apiClient.GetAsync<Product>($"products/{id}");
        }

        public async Task<bool> AddProductAsync(Product prod)
        {
            var response = await _apiClient.PostAsync<Product, Product>("products", prod);
            return response != null;
        }

        public async Task<bool> UpdateProductAsync(Product prod)
        {
            return await _apiClient.PutAsync<Product>($"products/{prod.Id}", prod);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _apiClient.DeleteAsync($"products/{id}") != null;
        }
    }
}
