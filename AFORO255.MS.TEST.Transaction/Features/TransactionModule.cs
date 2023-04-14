using Carter;
using AFORO255.MS.TEST.Transaction.Features.DTOs;
using AFORO255.MS.TEST.Transaction.Features.Services;

namespace AFORO255.MS.TEST.Transaction.Features;

public class TransactionModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/transaction/{idInvoce}", GetInvoce)
           .Produces<TransactionResponse>()
           .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetInvoce(int idInvoce, ITransactionService service)
    {
        var transactions = await service.GetById(idInvoce);
        if (transactions is null)  return Results.NotFound();

        return Results.Ok(transactions);
    }
}

