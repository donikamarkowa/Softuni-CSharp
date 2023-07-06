using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;

        public EventController(HomiesDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult All()
        {
            var events = context.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToList();  

            return View(events);
                
        }


        [Authorize]   
        public IActionResult Joined()
        {
            string currentUserId = GetUserId();
            var currentUser = context.Users.Find(currentUserId);

            var events = context.EventParticipants
                .Where(ep => ep.Helper == currentUser)
                .Select(ep => new EventViewModel
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name,
                    Organiser = GetUserId()
                })
                .ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            EventFormViewModel eventModel = new()
            {
                Types = context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList()
            };

            return View(eventModel);
        }

        [HttpPost]
        public IActionResult Add(EventFormViewModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            var newEvent = new Event()
            {
                Name = eventModel.Name,
                Description = eventModel.Description,
                OrganiserId = GetUserId(),
                Start = DateTime.ParseExact(eventModel.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                End = DateTime.ParseExact(eventModel.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                TypeId = eventModel.TypeId
            };

            context.Events.Add(newEvent);
            context.SaveChanges();

            return RedirectToAction("All", "Event");

        }

        public IActionResult Edit(int id)
        {
            var newEvent = context.Events.Find(id);

            if (newEvent == null)
            {
                return BadRequest();
            }

            EventFormViewModel eventViewModel = new EventFormViewModel()
            {
                Name = newEvent.Name,
                Description = newEvent.Description,
                Start = newEvent.Start.ToString("yyyy-MM-dd H:mm"),
                End = newEvent.End.ToString("yyyy-MM-dd H:mm"),
                TypeId = newEvent.TypeId,
                Types = context.Types
                .Select(t => new TypeViewModel {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList()
            };

            return View(eventViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EventFormViewModel eventViewModel)
        {
            var searchedEvent = context.Events.Find(id);
            if (searchedEvent == null)
            {
                return BadRequest();
            }

            searchedEvent.Name = eventViewModel.Name;
            searchedEvent.Description = eventViewModel.Description;
            searchedEvent.Start = DateTime.ParseExact(eventViewModel.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture);
            searchedEvent.End = DateTime.ParseExact(eventViewModel.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture);
            searchedEvent.TypeId = eventViewModel.TypeId;

            context.SaveChanges();
            return RedirectToAction("All", "Event");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Join(int id)
        {
            var searchedEvent = context.Events.Find(id);

            if (searchedEvent == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new EventParticipant()
            {
                EventId = searchedEvent.Id,
                HelperId = currentUserId
            };

            if (context.EventParticipants.Contains(entry))
            {
                return RedirectToAction("Joined", "Event");
            }

            context.EventParticipants.Add(entry);
            context.SaveChanges();
            return RedirectToAction("Joined", "Event");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Leave(int id)
        {

            var searchedUser = GetUserId();
            var searchedEvent = context.Events.Find(id);

            if (searchedEvent == null)
            {
                return BadRequest();
            }

            var entry = context.EventParticipants
                .FirstOrDefault(ep => ep.HelperId == searchedUser && ep.EventId == searchedEvent.Id);
            context.EventParticipants.Remove(entry);
            context.SaveChanges();

            return RedirectToAction("Joined", "Event");
        }
        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

    
}
