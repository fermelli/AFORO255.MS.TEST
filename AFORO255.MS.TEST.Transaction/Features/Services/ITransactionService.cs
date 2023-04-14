using AFORO255.MS.TEST.Transaction.Features.DTOs;
using AFORO255.MS.TEST.Transaction.Features.Models;

namespace AFORO255.MS.TEST.Transaction.Features.Services;

public interface ITransactionService
{
    Task<IEnumerable<TransactionResponse>> GetById(int idInvoce);

    Task<bool> Add(TransactionModel transactionModel);
}

