using Microsoft.EntityFrameworkCore;
using MiniProjekt_API.Controllers;
using MiniProjekt_API.Data;

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

            app.MapGet("/persons", PersonController.ListAllPersons);
            app.MapGet("/persons/{id}/interests/links", LinkController.ListPersonLink);
            app.MapGet("/persons/{id}/interests", InterestController.ListPersonInterests);

            app.MapGet("/links", LinkController.ListAllLinks);
            app.MapGet("/interests", InterestController.ListAllInterests);

            app.MapPost("/persons/{id}/interests", PersonController.AddNewInterest);
            app.MapPost("/persons/{personId}/interests/{interestId}/links", LinkController.AddNewLink);
            app.MapPost("/persons/{personId}/interests/{interestId}", PersonController.AddExistingInterest);

            app.Run();
        }
    }
}
