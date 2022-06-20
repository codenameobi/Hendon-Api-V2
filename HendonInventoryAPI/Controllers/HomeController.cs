using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HendonInventoryAPI.Interfaces;
using HendonInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HendonInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        public IEventsRepository _eventService;

        public HomeController(IEventsRepository service)
        {
            _eventService = service;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Event> events = _eventService.GetEvents();
            return Ok(events);
        }

        [Route("Available")]
        [HttpGet]
        public IActionResult Available()
        {
            IEnumerable<EquipmentInUse> events = _eventService.GetEquipmentsInUse();
            return Ok(events);
        }

    }
}

