using AFORO255.MS.TEST.Invoce.Persistences;

namespace AFORO255.MS.TEST.Invoce.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();

            if (context.Invoce.Any()) return;

            var invoces = new Models.InvoceModel[]
            {
                new Models.InvoceModel{Amount=200, State=0},
                new Models.InvoceModel{Amount=300, State=0},
                new Models.InvoceModel{Amount=40, State=0},
                new Models.InvoceModel{Amount=50, State=0},
                new Models.InvoceModel{Amount=100, State=0},
                new Models.InvoceModel{Amount=400, State=0},
                new Models.InvoceModel{Amount=200, State=0},
                new Models.InvoceModel{Amount=1000, State=0},
                new Models.InvoceModel{Amount=99, State=0},
                new Models.InvoceModel{Amount=999, State=0},
                new Models.InvoceModel{Amount=666, State=0},
                new Models.InvoceModel{Amount=123, State=0},
                new Models.InvoceModel{Amount=5000, State=0},
                new Models.InvoceModel{Amount=1111, State=0},
            };

            foreach (Models.InvoceModel s in invoces)
            {
                context.Invoce.Add(s);
            }

            context.SaveChanges();
        }
    }
}
