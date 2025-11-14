using IndigoApp.Domain.Entities;
using IndigoApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IndigoAppDbContext _ctx;

        public ProductRepository(IndigoAppDbContext context)
        {
            _ctx = context;
        }

        public async Task AddProductAsync(Product prod)
        {
            _ctx.Products.Add(prod);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _ctx.Products.FindAsync(id);
            if (product != null)
            {
                _ctx.Products.Remove(product);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _ctx.Products.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(int id) => await _ctx.Products.FindAsync(id);

        public async Task UpdateProductAsync(Product prod)
        {
            _ctx.Products.Update(prod);
            await _ctx.SaveChangesAsync();
        }
    }
}
