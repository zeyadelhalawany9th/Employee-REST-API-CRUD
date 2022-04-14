using Microsoft.EntityFrameworkCore;
using REST_API_CRUD.Models;
using REST_API_CRUD.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextPool<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("EmployeeContextConnectionString")));


builder.Services.AddScoped<IEmployee, SQLEmployee>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
