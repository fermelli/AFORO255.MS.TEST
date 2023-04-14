using AFORO255.MS.TEST.Invoce.Persistences;

namespace AFORO255.MS.TEST.Invoce.Services;

public class InvoceService : IInvoceService
{
    private readonly ContextDatabase _contextDatabase;

    public InvoceService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

    public IEnumerable<Models.InvoceModel> GetAll()
    {
        return _contextDatabase.Invoce.ToList();
    }
}

