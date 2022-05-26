namespace ShopsRUsRetailStore.API.Models
{
    public class GeneralDiscount : IDiscount
    {
        public decimal calculate(List<InvoiceItem> invoiceItems)
        {
            decimal totalCost = 0;

            foreach (var item in invoiceItems)
            {
                totalCost += item.Cost;
            }

            if (totalCost < 0)
            {
                return 0m;
            }
            else
            {
                return Math.Floor(totalCost / 100) * 5;
            }
        }
    }
}
