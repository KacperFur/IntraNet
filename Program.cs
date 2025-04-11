using FluentValidation;
using FluentValidation.AspNetCore;
using IntraNet;
using IntraNet.Entities;
using IntraNet.Extensions;
using IntraNet.Middleware;
using IntraNet.Models;
using IntraNet.Models.Validators;
using IntraNet.Seeders;
using IntraNet.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with connection configuration
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddApplicationServices();
builder.Services.AddMiddleware();
builder.Services.AddHasher();
builder.Services.AddApplicationSeeders();
builder.Services.AddValidators();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();
await app.SeedDatabaseAsync();

//Setting up swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intranet API");
});

// Dodanie routingu
app.UseRouting();

//authorization here
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();


