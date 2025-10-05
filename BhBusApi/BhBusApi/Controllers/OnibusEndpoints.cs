using Microsoft.EntityFrameworkCore;
using BhBusApi.Data;
using BhBusApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BhBusApi.Controllers;

public static class OnibusEndpoints
{
    public static void MapOnibusEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Onibus").WithTags(nameof(Onibus));

        group.MapGet("/", async (BhBusApiContext db) =>
        {
            return await db.Onibus.ToListAsync();
        })
        .WithName("GetAllOnibus")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Onibus>, NotFound>> (int id, BhBusApiContext db) =>
        {
            return await db.Onibus.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Onibus model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetOnibusById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Onibus onibus, BhBusApiContext db) =>
        {
            var affected = await db.Onibus
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, onibus.Id)
                    .SetProperty(m => m.Nome, onibus.Nome)
                    .SetProperty(m => m.Numero, onibus.Numero)
                    .SetProperty(m => m.Cor, onibus.Cor)
                    .SetProperty(m => m.Tipo, onibus.Tipo)
                    .SetProperty(m => m.Peso, onibus.Peso)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateOnibus")
        .WithOpenApi();

        group.MapPost("/", async (Onibus onibus, BhBusApiContext db) =>
        {
            db.Onibus.Add(onibus);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Onibus/{onibus.Id}",onibus);
        })
        .WithName("CreateOnibus")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, BhBusApiContext db) =>
        {
            var affected = await db.Onibus
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteOnibus")
        .WithOpenApi();
    }
}
