namespace AFORO255.MS.TEST.Transaction.Features.DTOs;
public class TransactionResponse
{
    public int? IdTransaction { get; set; }
    public int? IdInvoce { get; set; }
    public decimal? Amount { get; set; }
    public DateOnly? Date { get; set; }
}
