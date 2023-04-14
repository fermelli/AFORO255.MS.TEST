﻿using AFORO255.MS.TEST.Invoce.Persistences;

namespace AFORO255.MS.TEST.Invoce.Data;

public static class DbCreated
{
    public static void CreateDbIfNotExists(IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ContextDatabase>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocurrio un error al crear la BBDD.");
            }
        }
    }
}

