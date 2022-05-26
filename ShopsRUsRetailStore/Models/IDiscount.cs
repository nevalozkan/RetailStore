namespace ShopsRUsRetailStore.API.Models
{
    public interface IDiscount
    {
        decimal calculate(List<InvoiceItem> invoiceItems);
    }
}
