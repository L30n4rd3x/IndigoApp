using System;
using System.Collections.Generic;

namespace IndigoApp.Domain.DTOs
{
    public class CreateSaleRequest
    {
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
        public List<SaleDetailRequest> SaleDetails { get; set; } = new();
    }

    public class SaleDetailRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}