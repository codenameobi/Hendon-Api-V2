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

        [Route("all-events-equpiments")]
        [HttpGet]
        public async Task<ActionResult<Event>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Events
                .Include(s => s.EquipmentIns)
                .ThenInclude(i => i.Equipment)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [Route("create-new-equpiments")]
        [HttpPost]
        public async Task<IActionResult> Create(Equipment equpiment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Equipments.Add(equpiment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return Ok(equpiment);
        }



        //[Route("works")]
        //[HttpGet]
        //public async Task<ActionResult<>> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Events
        //        .Include(s => s.EquipmentIns)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.EventID == id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(student);
        //}

    }
}

