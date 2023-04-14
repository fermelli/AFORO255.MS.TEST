using AFORO255.MS.TEST.Security.Persistences;

namespace AFORO255.MS.TEST.Security.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    {
        context.Database.EnsureCreated();

        if (context.Access.Any()) return;

        var orders = new Models.Access[]
        {
                new Models.Access{Username="aforo255",Password="123456"},
                new Models.Access{Username="fermelli",Password="654321"},
                new Models.Access{Username="evecita",Password="123123"},
        };
        foreach (Models.Access s in orders)
        {
            context.Access.Add(s);
        }
        context.SaveChanges();
    }
}
