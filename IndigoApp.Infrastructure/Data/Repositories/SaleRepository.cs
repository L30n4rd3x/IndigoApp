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
    public class SaleRepository : ISaleRepository
    {
        private readonly IndigoAppDbContext _ctx;

        public SaleRepository(IndigoAppDbContext context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<Sale>> AddSaleAsync(Sale sale)
        {
            _ctx.Sales.Add(sale);
            await _ctx.SaveChangesAsync();
            return (IEnumerable<Sale>)sale;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync() => await _ctx.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                    .ThenInclude(sd => sd.Product)
                .OrderByDescending(s => s.Id)
                .ToListAsync();

        public async Task<Sale?> GetSaleByIdAsync(int id) => await _ctx.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                    .ThenInclude(sd => sd.Product)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate) => await _ctx.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                    .ThenInclude(sd => sd.Product)
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
    }
}
