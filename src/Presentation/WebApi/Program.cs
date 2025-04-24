
using System.Reflection;
using Application;
using Application.Repositores;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.Context;
using Persistance.IdentityModel;


namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                    
            //Add services to the container.
           builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer());
            builder.Services.AddControllers();

            builder.Services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();  // Required
            builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddApplication();
            builder.Services.AddInfra(builder.Configuration);
            builder.Services.AddPersistance(builder.Configuration);

            builder.Services.AddScoped<IProductRepositories, ProductRepositories>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               
                    app.UseSwagger();  // Enable Swagger in development environment
                    app.UseSwaggerUI();  // Enable Swagger UI (UI will be available at /swagger)
                

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
