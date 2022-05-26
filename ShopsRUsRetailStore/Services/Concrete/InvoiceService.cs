using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Services.Abstract;

namespace ShopsRUsRetailStore.API.Services.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDiscountFactory discountFactory;
        public InvoiceService(IDiscountFactory discountFactory)
        {
            this.discountFactory = discountFactory;
        }

        public decimal getFinalInvoiceAmount(Invoice invoice)
        {
            decimal totalCost = 0;
            decimal totalDiscount = 0;

            if (invoice.Customer != null && invoice.InvoiceItems != null)
            {
                List<IDiscount> discounts = this.discountFactory.getApplicableDiscounts(invoice.Customer);

                foreach (var item in invoice.InvoiceItems)
                {
                    totalCost += item.Cost;
                }

                foreach (var discount in discounts)
                {
                    totalDiscount += discount.calculate(invoice.InvoiceItems);
                }
            }

            return totalCost - totalDiscount;
        }
    }
}
