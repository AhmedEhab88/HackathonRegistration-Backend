using HackathonRegistration.Application.Services.Implementations;
using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Repositories;
using HackathonRegistration.Infrastructure;
using HackathonRegistration.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HackathonRegistrationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HackathonRegistrationDb")));

builder.Services.AddIdentityCore<IdentityUser>()
     .AddEntityFrameworkStores<HackathonRegistrationDbContext>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
