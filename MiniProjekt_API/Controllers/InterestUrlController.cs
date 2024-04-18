using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjekt_API.Models;
using MiniProjekt_API.Models.DTO;
using MiniProjekt_API.Models.ViewModels;
using MiniProjekt_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MiniProjekt_API.Controllers
{
    public class InterestUrlController : ControllerBase
    {
        public static IResult ListPersonUrl(ApiContext context, int id)
        {
            InterestUrlsViewModel[] result = context.InterestUrls
                .Include(i => i.Interests.People)
                .Where(i => i.People.Id == id)
                .Select(x => new InterestUrlsViewModel()
                {
                    url = x.Url,
                }).ToArray();
            return Results.Json(result);
        }

        public static IResult AddNewUrl(ApiContext context, int personId, int interestId, InterestUrlsDTO url)
        {
            var person = context.People
                    .Include(p => p.Interests)
                    .FirstOrDefault(p => p.Id == personId);

            if (person == null && person.Interests.Any(x => x.Id != interestId))
            {
                return Results.NotFound();
            }

            var interest = context.Interests
                    .Include(p => p.InterestUrls)
                    .Where(p => p.Id == interestId)
                    .FirstOrDefault();

            if (interest == null)
            {
                return Results.NotFound();
            }

            if (string.IsNullOrEmpty(url.Url))
            {
                return Results.BadRequest(new { Message = "No Url was provided" });
            }

            var newUrl = new InterestUrls
            {
                Url = url.Url,
                People = person,
                Interests = interest
            };

            interest.InterestUrls.Add(newUrl);

            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult ListAllUrls(ApiContext context)
        {
            InterestUrlsViewModel[] result = context.InterestUrls
                .Include(x => x.Interests)
                .Select(x => new InterestUrlsViewModel
                
                {
                    id = x.Interests.Id,
                    url = x.Url
                }).ToArray();

            return Results.Json(result);

        }
    }
}

