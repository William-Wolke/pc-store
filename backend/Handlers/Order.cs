using Microsoft.OpenApi.Models;
using PcStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PcStore.Enpoints;
public class OrderEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/orders", async (PcDbContext db) =>
        {
            return await db.Computers.ToListAsync();
        });
        app.MapGet("/orders", async (PcDbContext db) => await db.Computers.ToListAsync());
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
            if (order is null)
            {
                return Results.NotFound();
            }
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
    }
}
