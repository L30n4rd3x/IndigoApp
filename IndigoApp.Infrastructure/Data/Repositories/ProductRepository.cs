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
            _ctx.Prods.Add(prod);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _ctx.Prods.FindAsync(id);
            if (product != null)
            {
                _ctx.Prods.Remove(product);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _ctx.Prods.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(int id) => await _ctx.Prods.FindAsync(id);

        public async Task UpdateProductAsync(Product prod)
        {
            _ctx.Prods.Update(prod);
            await _ctx.SaveChangesAsync();
        }
    }
}
