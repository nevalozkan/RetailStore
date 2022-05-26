using ShopsRUsRetailStore.API.Models;

namespace ShopsRUsRetailStore.API.Services.Abstract
{
    public interface IInvoiceService
    {
        Decimal getFinalInvoiceAmount(Invoice invoice);
    }
}
