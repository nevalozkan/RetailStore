using Moq;
using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Models.Enums;
using ShopsRUsRetailStore.API.Services.Abstract;
using ShopsRUsRetailStore.API.Services.Concrete;
using ShopsRUsRetailStore.Controllers;
using Xunit;

namespace ShopsRUsRetailStore.UnitTests
{
    public class IntegrationTest
    {
        public static IEnumerable<object[]> TestGetFinalInvoiceAmountData()
        {
            List<object[]> inputs = new List<object[]>();

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Employee,RegistrationDate=DateTime.Now, Name="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Technology },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                    }
                },
                16.8m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Affiliate,RegistrationDate=DateTime.Now, Name="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Technology },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                    }
                },
                99m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Standard,RegistrationDate=new DateTime(2018, 8, 18), Name ="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Technology },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Clothing }
                    }
                },
                103.50m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Standard,RegistrationDate=DateTime.Now.AddDays(-3), Name ="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Clothing },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Technology }
                    }
                },
                109m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Employee,RegistrationDate=DateTime.Now.AddDays(-3), Name ="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Technology },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Clothing }
                    }
                },
                76m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerTypes.Employee,RegistrationDate=new DateTime(2018, 8, 18), Name ="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Clothing },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Grocery }
                    }
                },
                16.8m
            });

            inputs.Add(new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= (CustomerTypes)5,RegistrationDate=DateTime.Now.AddDays(-3), Name ="Neval",Surname="Ozkan Yeleser"},
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemTypes.Clothing },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemTypes.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemTypes.Technology }
                    }
                },
                114m
            });

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestGetFinalInvoiceAmountData))]
        public void TestGetFinalInvoiceAmount(Invoice invoice, decimal expected)
        {
            //Arrange
            decimal actual = 0m;

            IDiscountFactory factory = new DiscountFactory();
            
            IInvoiceService invoiceService = new InvoiceService(factory);

            InvoiceController invoiceController = new InvoiceController(invoiceService);

            //Act

            actual = invoiceController.GetFinalInvoiceAmount(invoice);            

            //Assert
            Assert.Equal(expected, actual);
           
        }
    }
}