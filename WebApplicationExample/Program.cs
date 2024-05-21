using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using WebApplicationExample;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(PersonValidator));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<OsobaDb>(options =>
    options.UseInMemoryDatabase("OsobyDb"));

var app = builder.Build();



// Definiowanie EndPoint'ów interfejsu API
app.MapPost("/osoby", async (Osoba osoba, OsobaDb db, IValidator<Osoba> validator) =>
{
    try
    {
        // Walidacja danych przychodz¹cych
        var validationResult = validator.Validate(osoba);
        if (!validationResult.IsValid)
        {
            // W przypadku b³êdnych danych zwracamy odpowiedŸ z b³êdami
            return Results.BadRequest(validationResult.Errors);
        }

        db.Osoby.Add(osoba);
        await db.SaveChangesAsync();
        return Results.Created($"/osoby/{osoba.Id}", osoba);
    }
    catch (Exception ex)
    {
        return Results.BadRequest("Nie wykonano rz¹dania");
    }
});

app.MapGet("/osoby", async (OsobaDb db) =>
{
    try
    {
        var osoby = await db.Osoby.ToListAsync();
        return Results.Ok(osoby);
    }
    catch (Exception ex)
    {
        return Results.BadRequest("Nie wykonano rz¹dania");
    }
});

app.MapGet("/osoby/{id:int}", async (int id, OsobaDb db) =>
{
    try
    {
        var osoba = await db.Osoby.FindAsync(id);
        if (osoba == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(osoba);
    }
    catch (Exception ex)
    {
        return Results.BadRequest("Nie wykonano rz¹dania");
    }
});




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

