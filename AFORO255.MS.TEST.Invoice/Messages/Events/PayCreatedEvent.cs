using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Invoice.Messages.Events;
public class PayCreatedEvent: Event
{
    public PayCreatedEvent(int idOperation, int idInvoce, decimal amount, DateTime? date)
    {
        IdOperation = idOperation;
        IdInvoce = idInvoce;
        Amount = amount;
        Date = date;
    }

    public int IdOperation { get; set; }
    public int IdInvoce { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Date { get; set; }
}
