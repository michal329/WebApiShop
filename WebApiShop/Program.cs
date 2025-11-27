using Repositories;
using service;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register services for dependency injection
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPasswordServices, PasswordServices>();
builder.Services.AddScoped<IUserRepositories, UserRepositories>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
