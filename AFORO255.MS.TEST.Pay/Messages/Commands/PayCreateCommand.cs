using Aforo255.Cross.Event.Src.Commands;

namespace AFORO255.MS.TEST.Pay.Messages.Commands;
public class PayCreateCommand: Command
{
    public int IdOperation { get; protected set; }
    public int IdInvoce { get; protected set; }
    public decimal Amount { get; protected set; }
    public DateTime? Date { get; protected set; }

    public PayCreateCommand(int idOperacion, int idInvoce, decimal amount, DateTime? date)
    {
        IdOperation = idOperacion;
        IdInvoce = idInvoce;
        Amount = amount;
        Date = date;
    }
}

