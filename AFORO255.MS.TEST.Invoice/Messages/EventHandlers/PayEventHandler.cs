using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoce.Services;
using AFORO255.MS.TEST.Invoice.Messages.Events;

namespace AFORO255.MS.TEST.Invoice.Messages.EventHandlers;

public class PayEventHandler: IEventHandler<PayCreatedEvent>
{
    private readonly IInvoceService _invoceService;

    public PayEventHandler(IInvoceService invoceService)
    {
        _invoceService = invoceService;
    }

    public Task Handle(PayCreatedEvent @event)
    {
        _invoceService.ChangeState(@event.IdInvoce);

        return Task.CompletedTask;
    }
}
