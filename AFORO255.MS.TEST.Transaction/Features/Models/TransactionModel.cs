using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AFORO255.MS.TEST.Transaction.Features.Models;

public class TransactionModel
{
    [BsonId]
    public ObjectId Id { get; set; }
    public int? IdTransaction { get; set; }
    public int? IdInvoce { get; set; }
    public decimal? Amount { get; set; }
    public DateOnly? Date { get; set; }
}

