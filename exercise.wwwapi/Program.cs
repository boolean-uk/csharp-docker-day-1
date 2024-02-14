using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;
using exercise.wwwapi.Models.Models.StudentCourses;
using exercise.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
builder.Services.AddScoped<IRepository<StudentCourse>, Repository<StudentCourse>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyProjectMigrations();
}

app.UseHttpsRedirection();

app.StudentEndpointConfiguration(); //core
app.CourseEndpointConfiguration(); //extension


app.Run();

