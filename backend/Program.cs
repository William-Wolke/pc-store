using Microsoft.OpenApi.Models;
using PcStore.Models;
using PcStore.Enpoints;
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

ComputerEndpoints.Map(app);

OrderEndpoints.Map(app);

app.Run();
