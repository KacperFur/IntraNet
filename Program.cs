using FluentValidation;
using FluentValidation.AspNetCore;
using IntraNet;
using IntraNet.Entities;
using IntraNet.Middleware;
using IntraNet.Models;
using IntraNet.Models.Validators;
using IntraNet.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();

var authenticationSettings = new AuthenticationSetting();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    System.ArgumentNullException: 'Value cannot be null. (Parametercfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});
// Add DbContext with connection configuration
builder.Services.AddDbContext<IntraNetDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<RoleSeeder>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
builder.Services.AddScoped<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();
using (var scope = app.Services.CreateScope())
{
    var myService = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
    myService.Seed();
}

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


