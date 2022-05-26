namespace ShopsRUsRetailStore.API.Models
{
    public class NonGroceryDiscount : IDiscount
    {
        private readonly decimal discountPercentage = 0m;

        public NonGroceryDiscount(decimal discountPercentage) 
        {
          this.discountPercentage = discountPercentage;
        }
        public decimal calculate(List<InvoiceItem> invoiceItems)
        {
            decimal nonGroceryAmount = 0;

            foreach (var item in invoiceItems)
            {
                if (item.Type != Enums.InvoiceItemTypes.Grocery)
                {
                    nonGroceryAmount += item.Cost;
                }
            }

            return Decimal.Multiply(nonGroceryAmount, this.discountPercentage);
        }
    }
}
