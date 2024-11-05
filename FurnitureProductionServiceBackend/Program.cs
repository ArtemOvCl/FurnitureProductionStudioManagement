using Microsoft.EntityFrameworkCore;
using FurnitureProductionServiceBackend.Data;
using FurnitureProductionServiceBackend.Repositories;
using FurnitureProductionServiceBackend.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FurnitureProductionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FurnitureProductionDatabase")));

builder.Services.AddScoped(typeof(IClassificatorRepository<>), typeof(ClassificatorRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireLogisticianRole", policy => policy.RequireRole("Logistician"));
    options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Common"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Welcome to the Furniture Production Service API!");

app.MapControllers();

app.Run();
