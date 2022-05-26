using ShopsRUsRetailStore.API.Models.Enums;

namespace ShopsRUsRetailStore.API.Models
{
    public class InvoiceItem
    {
        public InvoiceItemTypes Type { get; set; }
        public decimal Cost { get; set; }
    }
}
