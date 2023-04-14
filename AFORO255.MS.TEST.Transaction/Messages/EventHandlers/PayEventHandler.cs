using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Features.Services;
using AFORO255.MS.TEST.Transaction.Features.Models;

namespace AFORO255.MS.TEST.Transactiones.EventHandlers;

public class PayEventHandler: IEventHandler<PayCreatedEvent>
{
    private readonly ITransactionService _transactionService;

    public PayEventHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public Task Handle(PayCreatedEvent @event)
    {
        _transactionService.Add(new TransactionModel()
        {
            IdTransaction = @event.IdOperation,
            IdInvoce = @event.IdInvoce,
            Amount = @event.Amount,
            Date = DateTime.Now,
        });

        return Task.CompletedTask;
    }
}
