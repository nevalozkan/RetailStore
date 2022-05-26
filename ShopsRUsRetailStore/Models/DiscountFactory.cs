namespace ShopsRUsRetailStore.API.Models
{
    public  class DiscountFactory: IDiscountFactory
    {
       public  List<IDiscount> getApplicableDiscounts(Customer customer)
       {
            List<IDiscount> discounts = new List<IDiscount>();

            switch (customer.Type)
            {
                case Models.Enums.CustomerTypes.Employee:
                    discounts.Add(new NonGroceryDiscount(0.3m));
                    break;
                case Models.Enums.CustomerTypes.Affiliate:
                    discounts.Add(new NonGroceryDiscount(0.1m));
                    break;
                case Models.Enums.CustomerTypes.Standard:
                    if ((DateTime.Now - customer.RegistrationDate).TotalDays > 730)
                    {
                        discounts.Add(new NonGroceryDiscount(0.05m));
                    }
                    break;
                default:
                    return discounts;
            }
            
            discounts.Add(new GeneralDiscount());
            return discounts;   
        }
    }
}
