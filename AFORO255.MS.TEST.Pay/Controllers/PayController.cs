using Microsoft.AspNetCore.Mvc;
using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Services;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;
        private readonly IEventBus _eventBus;

        public PayController(IPayService payService, IEventBus eventBus)
        {
            _payService = payService;
            _eventBus = eventBus;
        }

        [HttpPost]
        public IActionResult Operation([FromBody] PayRequest request)
        {
            PayModel pay = new(request.IdInvoce, request.Amount);
            pay = _payService.Operation(pay);

            _eventBus.SendCommand(new PayCreateCommand(pay.IdOperation, pay.IdInvoce, pay.Amount, pay.Date));

            return Ok(pay);
        }
    }
}
