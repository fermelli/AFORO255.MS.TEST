using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using MediatR;

namespace AFORO255.MS.TEST.Pay.Messages.CommandsHandlers;
public class PayCommandHandler : IRequestHandler<PayCreateCommand, bool>
{
    private readonly IEventBus _bus;

    public PayCommandHandler(IEventBus bus) => _bus = bus;

    public Task<bool> Handle(PayCreateCommand request, CancellationToken cancellationToken)
    {
        _bus.Publish(new PayCreatedEvent(request.IdOperation, request.IdInvoce, request.Amount, request.Date));

        return Task.FromResult(true);
    }
}
