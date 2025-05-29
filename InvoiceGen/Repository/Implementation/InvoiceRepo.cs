using Dapper;
using InvoiceGen.Models;
using InvoiceGen.Repository.Interface;

namespace InvoiceGen.Repository.Implementation
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly DapperContext _context;
        public InvoiceRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(InvoiceDto invoice)
        {
            var query = @"
            INSERT INTO Invoices (InvoiceNumber, InvoiceDate, BillToName, BillToAddress, BillToEmail, ContactNo, 
                                  Price, TaxableAmount, ReceivedAmount, Disclaimer)
            VALUES (@InvoiceNumber, @InvoiceDate, @BillToName, @BillToAddress, @BillToEmail, @ContactNo, 
                    @Price, @TaxableAmount, @ReceivedAmount, @Disclaimer)"; 

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, invoice);
        }

        public async Task<int> DeleteAsync(string id)
        {
            var query = "Delete from Invoices where InvoiceNumber = @InvoiceNumber";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new {InvoiceNumber = id});
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            var query = "Select * from Invoices";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Invoice>(query);
        }

        public async Task<Invoice> GetByIdAsync(string id)
        {
            var query = "SELECT * FROM Invoices WHERE InvoiceNumber = @InvoiceNumber";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Invoice>(query, new { InvoiceNumber = id });
        }

        public async Task<int> UpdateAsync(int id, InvoiceDto invoice)
        {
            var query = @"
            UPDATE Invoices SET
                
                InvoiceDate = @InvoiceDate,
                BillToName = @BillToName,
                BillToAddress = @BillToAddress,
                BillToEmail = @BillToEmail,
                ContactNo = @ContactNo,
                Price = @Price,
                TaxableAmount = @TaxableAmount,
                ReceivedAmount = @ReceivedAmount,
                Disclaimer = @Disclaimer
            WHERE InvoiceNumber= @InvoiceNumber";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, invoice);
        }
    }
}
