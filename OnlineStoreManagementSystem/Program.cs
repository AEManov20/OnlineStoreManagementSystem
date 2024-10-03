using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem;
using OnlineStoreManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddLogging();
builder.AddAutoMapper();
builder.AddDbContext();

builder.AddServices();
builder.AddSwagger();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying migrations.");
    }
} 

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();