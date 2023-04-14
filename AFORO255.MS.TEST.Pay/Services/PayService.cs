using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Persistences;
using AFORO255.MS.TEST.Pay.Services;

namespace MS.AFORO255.Deposit.Services;

public class PayService : IPayService
{
    private readonly ContextDatabase _contextDatabase;

    public PayService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

    public PayModel Operation(PayModel pay)
    {
        _contextDatabase.PayModel.Add(pay);
        _contextDatabase.SaveChanges();

        return pay;
    }

    public PayModel OperationReverse(PayModel pay)
    {
        _contextDatabase.PayModel.Add(pay);
        _contextDatabase.SaveChanges();

        return pay;
    }
}

