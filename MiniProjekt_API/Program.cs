using Microsoft.EntityFrameworkCore;
using MiniProjekt_API.Controllers;
using MiniProjekt_API.Data;
using MiniProjekt_API.Models;
using System;

namespace MiniProjekt_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApiContext");
            builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();
            app.MapGet("/", () => "Welcome to my Api!");
            
                
            app.MapGet("/people", PersonController.ListAllPersons);
            app.MapGet("/people/{id}/interests/urls", InterestUrlController.ListPersonUrl);
            app.MapGet("/people/{id}/interests", InterestController.ListPersonInterests);
            app.MapGet("/urls", InterestUrlController.ListAllUrls);
            app.MapGet("/interests", InterestController.ListAllInterests);

            app.MapPost("/people/{id}/interests", PersonController.AddNewInterest);
            app.MapPost("/people/{personId}/interests/{interestId}/urls", InterestUrlController.AddNewUrl);
            app.MapPost("/persons/{personId}/interests/{interestId}", PersonController.AddPersonToInterest);
            
            app.Run();
        }
    }
}
