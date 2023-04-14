using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Persistences;

public interface IMongoBookDBContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}

