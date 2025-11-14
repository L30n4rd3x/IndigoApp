using IndigoApp.Domain.Entities;
using IndigoApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task AddProductAsync(Product prod)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product prod)
        {
            throw new NotImplementedException();
        }
    }
}
