using CompanyRegistry.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using CompanyRegistry.Controllers;
using CompanyRegistry.Data.Repositories;
using CompanyRegistry.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<UsersRepository>();
builder.Services.AddTransient<UsersServices>();
builder.Services.AddTransient<UserTypesRepository>();
builder.Services.AddTransient<UserTypesServices>();
builder.Services.AddTransient<CompanyTypesRepository>();
builder.Services.AddTransient<CompanyTypesServices>();
builder.Services.AddTransient<CompaniesRepository>();
builder.Services.AddTransient<CompaniesServices>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
// Configura��es para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection(); // Adicione esta linha para redirecionar HTTP para HTTPS
app.UseAuthorization();

app.MapControllers();

//app.MapUsersEndpoints();

app.Run();
