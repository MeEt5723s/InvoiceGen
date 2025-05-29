public class Invoice
{
    public int InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string BillToName { get; set; }
    public string BillToAddress { get; set; }
    public string BillToEmail { get; set; }
    public string ContactNo { get; set; }

    public decimal Price { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal CGST { get; set; }
    public decimal SGST { get; set; }
    public decimal NetAmount { get; set; }
    public decimal ReceivedAmount { get; set; }
    public decimal DueAmount { get; set; }

    public string Disclaimer { get; set; }
}
