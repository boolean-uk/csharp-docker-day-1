using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDockerInstance"));
    options.LogTo(message => Debug.WriteLine(message));

});
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

//using (var dbContext = new DataContext(new DbContextOptions<DataContext>()))
//{
//    dbContext.Database.EnsureCreated();
//}
app.UseHttpsRedirection();

app.ConfigurePeople();

app.Seed();

app.Run();

