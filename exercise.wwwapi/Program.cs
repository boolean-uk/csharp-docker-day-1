using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.Mapper;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.LogTo(message => Debug.WriteLine(message));
});

builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.StudentEndpointConfiguration(); //core
app.CourseEndpointConfiguration(); //extension
app.ApplyProjectMigrations();

app.Run();

