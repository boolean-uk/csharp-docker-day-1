using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ApplyProjectMigrations();
app.StudentEndpointConfiguration(); //core
app.CourseEndpointConfiguration(); //extension

app.Run();

