namespace InvoiceGen.Models
{
    public class InvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillToName { get; set; }
        public string BillToAddress { get; set; }
        public string BillToEmail { get; set; }
        public string ContactNo { get; set; }

        public decimal Price { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string Disclaimer { get; set; }

    }
}
