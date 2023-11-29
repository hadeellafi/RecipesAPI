using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using RecipesAPI.Data;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;
using RecipesAPI.Models.Services;

namespace RecipesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
               .AddDbContext<RecipesDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddTransient<IUser, UserService>();

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RecipesDbContext>();
            // Add services to the container.

            builder.Services.AddControllers();
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
        }
    }
}