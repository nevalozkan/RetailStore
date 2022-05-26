using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Models.Enums;
using ShopsRUsRetailStore.API.Services.Abstract;

namespace ShopsRUsRetailStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost("[action]")]
        public decimal GetFinalInvoiceAmount([FromBody()] Invoice request)
        {
          return this.invoiceService.getFinalInvoiceAmount(request);
        }
    }  
}