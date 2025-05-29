using InvoiceGen.Models;

namespace InvoiceGen.Repository.Interface
{
    public interface IInvoiceRepo
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(string id);
        Task<int> CreateAsync(InvoiceDto invoice);
        Task<int> UpdateAsync(int id, InvoiceDto invoice);
        Task<int> DeleteAsync(string id);
    }
}
