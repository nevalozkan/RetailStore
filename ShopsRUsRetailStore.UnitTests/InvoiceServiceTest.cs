using Moq;
using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Models.Enums;
using ShopsRUsRetailStore.API.Services.Abstract;
using ShopsRUsRetailStore.API.Services.Concrete;
using ShopsRUsRetailStore.Controllers;
using System.Collections.Generic;
using Xunit;

namespace ShopsRUsRetailStore.UnitTests
{
    public class InvoiceServiceTest
    {

        public static IEnumerable<object[]> TestGetFinalInvoiceAmountData()
        {
            List<object[]> inputs = new List<object[]>();
           
            inputs.Add(new object[] {
                new Invoice()
                {
                    Customer = new Mock<Customer>().Object,
                    InvoiceItems = new List<InvoiceItem>() {
                        new InvoiceItem {Cost=15.50m,Type=InvoiceItemTypes.Technology },
                        new InvoiceItem {Cost=30m,Type=InvoiceItemTypes.Clothing }
                    }
                },
                5m,
                2m,
                38.50m
            }) ;

            inputs.Add(new object[] {
                new Invoice()
                {
                    Customer = null,
                    InvoiceItems = null
                },
                5m,
                2m,
                0m
            });

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestGetFinalInvoiceAmountData))]
        public void TestGetFinalInvoiceAmount(Invoice invoice, decimal discount1Amount, decimal discount2Amount, decimal expected)
        {
            //Arrange

            Mock<IDiscount> discount1 = new Mock<IDiscount>();
            Mock<IDiscount> discount2 = new Mock<IDiscount>();
            discount1.Setup(d => d.calculate(It.IsAny<List<InvoiceItem>>())).Returns(discount1Amount);
            discount2.Setup(d => d.calculate(It.IsAny<List<InvoiceItem>>())).Returns(discount2Amount);

            var discountFactory = new Mock<IDiscountFactory>();
            discountFactory.Setup(d => d.getApplicableDiscounts(It.IsAny<Customer>())).Returns(new List<IDiscount>
            {
                discount1.Object, discount2.Object
            });

            //Act

            IInvoiceService service = new InvoiceService(discountFactory.Object);
            decimal actual = service.getFinalInvoiceAmount(invoice);

            //Assert

            Assert.Equal(expected, actual);
        }
    }
}