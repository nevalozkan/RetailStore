namespace ShopsRUsRetailStore.API.Models
{
    public class Invoice
    {
        public Customer?  Customer { get; set; }
        public List<InvoiceItem>? InvoiceItems { get; set; }

    }
}
