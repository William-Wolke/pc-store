using Microsoft.OpenApi.Models;
using PcStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PcStore") ?? "Data Source=PcStore.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "PC Shop API",
         Description = "Purchase PC",
         Version = "v1" });
});
builder.Services.AddSqlite<PcDbContext>(connectionString);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "PC Shop API V1");
});

app.MapGet("/", () => "Hello World!");

/* Computer endpoints */

app.MapGet("/computers", async (PcDbContext db) =>
{
    return await db.Computers.ToListAsync();
});
app.MapGet("/computer/{id}", async (PcDbContext db, int id) =>
{
    return await db.Computers.FindAsync(id);
});

app.MapPost("/computer", async (PcDbContext db, Computer computer) => 
{
    await db.Computers.AddAsync(computer);
    await db.SaveChangesAsync();
    return Results.Created($"/computer/{computer.Id}", computer);
});
app.MapPut("/computer/{id}", async (PcDbContext db, Computer updateComputer, int id) => 
{
    var computer = await db.Computers.FindAsync(id);
    if (computer is null || updateComputer is null) {
        return Results.NotFound();
    };
    computer.Name = updateComputer.Name ?? computer.Name;
    computer.Processor = updateComputer.Processor ?? computer.Processor;
    computer.GraphicsCard = updateComputer.GraphicsCard ?? computer.GraphicsCard;
    computer.Description = updateComputer.Description ?? computer.Description;
    computer.ImageLink = updateComputer.ImageLink ?? computer.ImageLink;

    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/computer/{id}", async (PcDbContext db, int id) => 
{
    var computer = await db.Computers.FindAsync(id);
    if (computer is null)
    {
        return Results.NotFound();
    }
    db.Computers.Remove(computer);
    await db.SaveChangesAsync();
    return Results.Ok();
});

/* Order endpoints */

app.MapGet("/orders", async (PcDbContext db) => 
{
    return await db.Computers.ToListAsync();
});
app.MapGet("/order/{id}", async (PcDbContext db, int id) =>
{
    return await db.Orders.FindAsync(id);
});

app.MapPost("/order", async (PcDbContext db, Order order) =>
{
    await db.Orders.AddAsync(order);
    await db.SaveChangesAsync();
    return Results.Created($"/order/{order.Id}", order);
});
app.MapPut("/order/{id}", async (PcDbContext db, Order updateOrder, int id) => 
{
    var order = await db.Orders.FindAsync(id);
    if (updateOrder is null) {
        return Results.NotFound();
    };
    order.CustomerName = updateOrder.CustomerName;
    order.Address = updateOrder.Address;
    order.Computers.Clear();
    foreach (var computer in updateOrder.Computers)
    {
        order.Computers.Add(computer);
    }
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/order/{id}", async (PcDbContext db, int id) => 
{
    var order = await db.Orders.FindAsync(id);
    if (order is null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(order);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
