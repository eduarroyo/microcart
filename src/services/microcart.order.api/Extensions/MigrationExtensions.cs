using microcart.order.api.Database;

namespace Products.Api.Extensions;

public static class MigrationExtensions
{
    public static async Task PrepareDatabase(this IApplicationBuilder app, bool isDevelopment)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using MicrocartDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<MicrocartDbContext>();

        if (isDevelopment)
        {
            await dbContext.Database.EnsureDeletedAsync();
        }
        await dbContext.Database.EnsureCreatedAsync();
    }
}