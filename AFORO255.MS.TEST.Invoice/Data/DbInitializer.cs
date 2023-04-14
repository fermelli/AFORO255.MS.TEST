using AFORO255.MS.TEST.Invoce.Persistences;

namespace AFORO255.MS.TEST.Invoce.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
