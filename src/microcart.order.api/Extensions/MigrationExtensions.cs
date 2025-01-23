using microcart.order.api.Database;
using Microsoft.EntityFrameworkCore;

namespace Products.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using MicrocartDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<MicrocartDbContext>();

        dbContext.Database.Migrate();
    }
}