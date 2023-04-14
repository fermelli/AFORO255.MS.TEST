using AFORO255.MS.TEST.Invoce.Models;

namespace AFORO255.MS.TEST.Invoce.Services;

public interface IInvoceService
{
    IEnumerable<Models.InvoceModel> GetAll();

    void ChangeState(int idInvoce);
}

