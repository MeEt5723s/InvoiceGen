using InvoiceGen.Models;
using InvoiceGen.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepo _repo;
        public InvoiceController(IInvoiceRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceDto invoice)
        {
            await _repo.CreateAsync(invoice);
            return Ok("Invoice created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceDto invoice)
        {
            await _repo.UpdateAsync(id, invoice);
            return Ok("Invoice updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Invoice deleted.");
        }
    }
}
