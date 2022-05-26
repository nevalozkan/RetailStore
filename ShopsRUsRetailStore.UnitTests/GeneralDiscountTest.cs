using Moq;
using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Models.Enums;
using Xunit;

namespace ShopsRUsRetailStore.UnitTests
{
    public class GeneralDiscountTest
    {
        public static IEnumerable<object[]> TestDiscountCalculationData ()
        {
            List<object[]> inputs = new List<object[]>();

            inputs.Add(new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 12, Type= InvoiceItemTypes.Technology },
                    new InvoiceItem { Cost = 25, Type= InvoiceItemTypes.Clothing },
                    new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                },
                0m
            });

            inputs.Add(new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 40, Type= InvoiceItemTypes.Technology },
                    new InvoiceItem { Cost = 50, Type= InvoiceItemTypes.Technology },
                    new InvoiceItem { Cost = 800, Type= InvoiceItemTypes.Grocery },
                    new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Grocery }
                },
                45m
            });

            inputs.Add(new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = -99, Type= InvoiceItemTypes.Clothing }
                },
                0m
            });

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestDiscountCalculationData))]
        public void TestDiscountCalculation(List<InvoiceItem> invoiceItems, decimal expected)
        {
            //Arrange

            decimal actual = 0m;

            IDiscount generalDiscount = new GeneralDiscount();

            //Act

            actual = generalDiscount.calculate(invoiceItems);

            //Assert

            Assert.Equal(expected, actual);

        }
    }
}