using Microsoft.AspNetCore.Mvc;
using MiniProjekt_API.Data;
using MiniProjekt_API.Models;
using MiniProjekt_API.Models.DTO;
using MiniProjekt_API.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MiniProjekt_API.Controllers
{
    public class PersonController
    {
        public static IResult ListAllPersons(ApiContext context)
        {
            PeopleViewModel[] result = context.People
                .Select(x => new PeopleViewModel()
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    phoneNumber = x.PhoneNumber,
                    age = x.Age
                }).ToArray();
            return Results.Json(result);
        }

        public static IResult AddNewInterest(ApiContext context, int id, InterestDTO NewInterest)
        {
            var person = context.People
                    .Include(p => p.Interests)
                    .FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return Results.NotFound();
            }

            var allInterests = context.Interests
                .ToArray();

            if (allInterests.Any(i => i.Name == NewInterest.Name))
            {
                return Results.Conflict("Interest already exists in the database");
            }

            if (string.IsNullOrEmpty(NewInterest.Name) || string.IsNullOrEmpty(NewInterest.Description) || string.IsNullOrEmpty(NewInterest.Title))
            {
                return Results.BadRequest(new { Message = "New interest needs to have a title, a name and a description" });
            }
            var interest = new Interests
            {
                Name = NewInterest.Name,
                Description = NewInterest.Description,
                Title = NewInterest.Title
            };

            person.Interests.Add(interest);


            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult AddPersonToInterest(ApiContext context, int personId, int interestId)
        {
            var person = context.People
                .Where(p => p.Id == personId)
                .Include(p => p.Interests)
                .SingleOrDefault();

            if (person == null)
            {
                return Results.Conflict("Person not found");
            }

            var interest = context.Interests
                .Where(i => i.Id == interestId)
                .Include(p => p.People)
                .SingleOrDefault();

            if (interest == null)
            {
                return Results.Conflict("Interest not found");
            }

            person.Interests.Add(interest);

            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
    
