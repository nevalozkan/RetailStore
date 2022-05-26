namespace ShopsRUsRetailStore.API.Models
{
    public interface IDiscountFactory
    {
        List<IDiscount> getApplicableDiscounts(Customer customer);
    }
}
