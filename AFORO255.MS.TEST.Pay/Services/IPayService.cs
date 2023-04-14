using AFORO255.MS.TEST.Pay.Models;

namespace AFORO255.MS.TEST.Pay.Services;

public interface IPayService
{
    PayModel Operation(PayModel transaction);
    PayModel OperationReverse(PayModel transaction);
}

