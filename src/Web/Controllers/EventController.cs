using System.Linq;
using Domain._Base;
using Domain.Events;
using Microsoft;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        public EventStorage _eventStorage;
        public IBaseRepository<Event> _eventRepository;
        public EventController(EventStorage eventStorage, IBaseRepository<Event> eventRepository)
        {
            _eventStorage = eventStorage;
            _eventRepository = eventRepository;
        }

        public IActionResult Index()
        {
            var events = _eventRepository.Search();

            if (events.Any())
            {
                var dtos = events.Select(c => new EventDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate.ToString("dd/MM/yyyy"),
                    FinishDate = c.FinishDate.ToString("dd/MM/yyyy")
                });
                return View("List", dtos);
            }

            return View("List", events);
        }

        public IActionResult New()
        {
            return View("NewOrEdit");
        }

        public IActionResult Edit(int id)
        {
            var eventObj = _eventRepository.SearchForId(id);
            var dto = new EventDto
            {
                Id = eventObj.Id,
                Name = eventObj.Name,
                Description = eventObj.Description,
                StartDate = eventObj.StartDate.ToString("yyyy-MM-dd"),
                FinishDate = eventObj.FinishDate.ToString("yyyy-MM-dd")
            };

            return View("NewOrEdit", dto);
        }

        public IActionResult Delete(int id)
        {
            _eventStorage.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Save(EventDto e)
        {
            _eventStorage.Add(e);
            return Ok();
        }
    }
}
