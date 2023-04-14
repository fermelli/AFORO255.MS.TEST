using AFORO255.MS.TEST.Pay.Persistences;

namespace AFORO255.MS.TEST.Pay.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    {
        context.Database.EnsureCreated();
        context.SaveChanges();
    }
}

