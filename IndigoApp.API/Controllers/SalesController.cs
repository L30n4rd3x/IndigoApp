using IndigoApp.Domain.DTOs;
using IndigoApp.Domain.Entities;
using IndigoApp.Domain.Interfaces;
using IndigoApp.Forms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndigoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepo)
        {
            _saleRepository = saleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleRepository.GetAllSalesAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _saleRepository.AddSaleAsync(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        [HttpGet("bydaterange")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
                return BadRequest("La fecha inicial no puede ser mayor que la final.");

            var sales = await _saleRepository.GetSalesByDateRangeAsync(startDate, endDate);

            return Ok(sales);
        }
    }
}