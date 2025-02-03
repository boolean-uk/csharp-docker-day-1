using api_cinema_challenge.Data;
using api_cinema_challenge.Endpoints;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddDbContext<DataContext>(options =>
{
    //var connectionString = configuration.GetConnectionString("DefaultConnectionString");
    var connectionString = configuration.GetConnectionString("LocalConnectionString");
    options.UseNpgsql(connectionString);

    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddScoped<IRepository<Customer, int>, Repository<Customer, int>>();
builder.Services.AddScoped<IRepository<Movie, int>, Repository<Movie, int>>();
builder.Services.AddScoped<IRepository<Screen, int>, Repository<Screen, int>>();
builder.Services.AddScoped<IRepository<Screening, int>, Repository<Screening, int>>();
builder.Services.AddScoped<IRepository<Seat, int>, Repository<Seat, int>>();
builder.Services.AddScoped<IRepository<Ticket, int>, Repository<Ticket, int>>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<DataContext>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCustomersEndpoints();
app.ConfigureMoviesEndpoints();
app.ConfigureScreeningsEndpoints();
app.ConfigureSeatsEndpoints();
app.ConfigureScreensEndpoints();
app.ConfigureTicketsEndpoints();

app.Run();
