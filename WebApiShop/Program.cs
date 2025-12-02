using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using service;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddScoped<IPasswordServices, PasswordServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddDbContext<MyUsersDBContext>
    (options => options.UseSqlServer("Data Source=DESKTOP-1VUANBN;Initial Catalog=MyUsersDB;Integrated Security=True;Trust Server Certificate=True"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyUsersDBContext>();
    db.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();