using Microsoft.AspNetCore.Mvc;
using AFORO255.MS.TEST.Invoce.Services;

namespace AFORO255.MS.TEST.Invoce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoceController : ControllerBase
    {
        private readonly IInvoceService _invoceService;

        public InvoceController(IInvoceService invoceService) => _invoceService = invoceService;

        [HttpGet]
        public IActionResult List()
        {
            var invoces = _invoceService.GetAll();

            return Ok(invoces);
        }
    }
}
