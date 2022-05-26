using Moq;
using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Models.Enums;
using Xunit;

namespace ShopsRUsRetailStore.UnitTests
{
    public class NonGroceryDiscountTest
    {
        public static IEnumerable<object[]> TestDiscountCalculationData ()
        {
            List<object[]> inputs = new List<object[]>();

            inputs.Add(new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 12, Type= InvoiceItemTypes.Clothing },
                    new InvoiceItem { Cost = 25, Type= InvoiceItemTypes.Technology },
                    new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                },
                0.1m,
                3.7m
            });

            inputs.Add(new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 12, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 25, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                },
                0.3m,
                0m
            });

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestDiscountCalculationData))]
        public void TestDiscountCalculation(List<InvoiceItem> invoiceItems, decimal percentage, decimal expected)
        {
            //Arrange

            decimal actual = 0m;

            IDiscount nonGroceryDiscount = new NonGroceryDiscount(percentage);

            //Act

            actual = nonGroceryDiscount.calculate(invoiceItems);

            //Assert

            Assert.Equal(expected, actual);

        }
    }
}