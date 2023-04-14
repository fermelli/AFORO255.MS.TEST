using Microsoft.AspNetCore.Mvc;
using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Services;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService) => _payService = payService;

        [HttpPost]
        public IActionResult Deposit([FromBody] PayRequest request)
        {
            PayModel pay = new(request.IdInvoce, request.Amount);
            pay = _payService.Operation(pay);

            return Ok(pay);
        }
    }
}
