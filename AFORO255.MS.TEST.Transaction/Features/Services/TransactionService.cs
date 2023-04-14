using MongoDB.Driver;
using AFORO255.MS.TEST.Transaction.Features.DTOs;
using AFORO255.MS.TEST.Transaction.Features.Models;
using AFORO255.MS.TEST.Transaction.Persistences;
using AFORO255.MS.TEST.Transaction.Features.Services;

namespace AFORO255.MS.TEST.Transaction.Services;

public class TransactionService : ITransactionService
{
    private readonly IMongoBookDBContext _context;
    protected IMongoCollection<TransactionModel> _dbCollection;
    public TransactionService(IMongoBookDBContext context)
    {
        _context = context;
        _dbCollection = _context.GetCollection<TransactionModel>(typeof(TransactionModel).Name);
    }

    public async Task<bool> Add(TransactionModel historyModel)
    {
        await _dbCollection.InsertOneAsync(historyModel);

        return true;
    }

    public async Task<IEnumerable<TransactionResponse>> GetById(int idInvoce)
    {
        var result = await _dbCollection.Find(x=> x.IdInvoce == idInvoce).ToListAsync();
        var response = new List<TransactionResponse>();
        foreach (var item in result)
        {
            response.Add(new TransactionResponse()
            {
                IdInvoce = item.IdInvoce,
                Amount = item.Amount,
                Date = item.Date,
            });
        }
        return response;
    }
}
