using EFCorePizzaStore;

using EFCorePizzaStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});

//builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

IConfiguration configuration = builder.Configuration;
var stringConnection = "PizzaDbConnectionString";
var connectionConfiguration = configuration.GetConnectionString(stringConnection);
if (connectionConfiguration == null)
{
    throw new ArgumentNullException(nameof(connectionConfiguration), $"{stringConnection} doesn't exist in your appsetings.json");
}

builder.Services.AddDbContext<PizzaDb>(options =>
            options.UseSqlServer(connectionConfiguration)
);

// SQLite
// - builder.Services.AddSqlite<PizzaDb>(connectionString);
// Run commandas
//  > Add-Migration InitialMigration
//  > Update-Database
// Run the app


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.UseHttpsRedirection();



app.MapGet("/api/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());


app.MapPost("/api/pizzas", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});


app.MapGet("/api/pizzas/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));


app.MapPut("/pizzas/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});


app.MapDelete("/api/pizzas/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
