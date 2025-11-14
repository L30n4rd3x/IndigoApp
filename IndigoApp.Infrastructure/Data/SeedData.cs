using IndigoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Cámara", Price = 250000.99m, Stock = 10, Image = "https://th.bing.com/th/id/R.d6493a52aedba532110e5d68c3361bc6?rik=7zW9xC9cwdLF5g&pid=ImgRaw&r=0" },
                new Product { Id = 2, Name = "Control PS4", Price = 192000.99m, Stock = 25, Image = "https://http2.mlstatic.com/controle-ps4-black-playstation-4-dualshock-4-original-sony-D_NQ_NP_139901-MLB20435039725_092015-F.jpg" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "adm123", RoleUser = "admin" },
                new User { Id = 2, Username = "user", Password = "user999", RoleUser = "user" }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, UserId = 1, Total = 442000.98m }
            );

            modelBuilder.Entity<SaleDetail>().HasData(
                new SaleDetail { Id = 1, SaleId = 1, ProductId = 1, UnitPrice = 250000.99m, Quantity = 1, Subtotal = 250000.99m },
                new SaleDetail { Id = 2, SaleId = 1, ProductId = 2, UnitPrice = 192000.99m, Quantity = 1, Subtotal = 192000.99m }
            );
        }
    }
}
