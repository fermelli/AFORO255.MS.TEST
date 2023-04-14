using AFORO255.MS.TEST.Security.Models;
using AFORO255.MS.TEST.Security.Persistences;

namespace AFORO255.MS.TEST.Security.Services;
public class AccessService : IAccessService
{
    private readonly ContextDatabase _contextDatabase;
    public AccessService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;
    public IEnumerable<Access> GetAll() => _contextDatabase.Access.ToList();
    public bool Validate(string? userName, string? password)
    {
        var list = _contextDatabase.Access.ToList();
        var access = list.FirstOrDefault(x => x.Username == userName && x.Password == password);
        
        if (access is not null) return true;

        return false;
    }
}
