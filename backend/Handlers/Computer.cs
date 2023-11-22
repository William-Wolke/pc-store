using Microsoft.OpenApi.Models;
using PcStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PcStore.Enpoints;
public class ComputerEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/computers", async (PcDbContext db) => await db.Computers.ToListAsync());
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
            if (computer is null || updateComputer is null)
            {
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
    }
}
