using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjekt_API.Models.ViewModels;
using MiniProjekt_API.Data;
using Microsoft.EntityFrameworkCore;

namespace MiniProjekt_API.Controllers
{

    public class InterestController : ControllerBase
    {

        public static IResult ListAllInterests(ApiContext context)
        {
            InterestViewModel[] result = context.Interests
                .Select(x => new InterestViewModel()
                {
                    id = x.Id,
                    name = x.Name,
                    description = x.Description,
                    title = x.Title
                }).ToArray();

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Json(result);
        }

        public static IResult ListPersonInterests(ApiContext context, int id)
        {
            InterestToPersonViewModel[] result = context.Interests
                .Include(x => x.People)
                .Where(x => x.People.Any(p => p.Id == id))
                .Select(x => new InterestToPersonViewModel
                {
                    firstName = x.People.FirstOrDefault().FirstName,
                    lastName = x.People.FirstOrDefault().LastName,
                    name = x.Name,
                    description = x.Description,
                    title = x.Title
                }).ToArray();

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Json(result);

        }
    }
}
