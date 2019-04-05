using System;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View("List");
        }

        public IActionResult New()
        {
            return View("NewOrEdit");
        }
    }
}
