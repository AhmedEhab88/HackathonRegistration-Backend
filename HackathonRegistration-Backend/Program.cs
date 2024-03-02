using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using HackathonRegistrationDbContext;
using Services;
using ServicesImplementation;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HackathonRegistration_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HackathonRegistrationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HackathonRegistrationDb")));

            builder.Services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<HackathonRegistrationContext>();

            builder.Services.AddScoped<ILoginService, LoginService>();

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
        }
    }
}
