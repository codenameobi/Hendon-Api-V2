using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HendonInventoryAPI.Data;
using HendonInventoryAPI.Interfaces;
using HendonInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HendonInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        public IEventsRepository _eventService;
        public HendonDb _context;

        public HomeController(IEventsRepository service, HendonDb context)
        {
            _eventService = service;
            _context = context;
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

        [Route("works")]
        [HttpGet]
        public async Task<ActionResult<Event>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Events
                .Include(s => s.EquipmentIns)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

    }
}

