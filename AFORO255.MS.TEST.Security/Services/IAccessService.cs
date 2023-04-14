using AFORO255.MS.TEST.Security.Models;

namespace AFORO255.MS.TEST.Security.Services;

public interface IAccessService
{
    IEnumerable<Access> GetAll();
    bool Validate(string? userName, string? password);
}
