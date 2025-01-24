using microcart.order.api.Database;
using microcart.order.api.Endpoints;
using Microsoft.EntityFrameworkCore;
using Products.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MicrocartDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("microcartdb"));
    }
);

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder.WithOrigins("http://localhost:52001/", "http://localhost:52001/swagger/index.html")
    )
);

var app = builder.Build();

app.MapProductEntpoints();
app.MapOrderEntpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

await app.PrepareDatabase(app.Environment.IsDevelopment());


app.Run();