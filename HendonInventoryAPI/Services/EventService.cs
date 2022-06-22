using System;
using HendonInventoryAPI.Data;
using HendonInventoryAPI.Interfaces;
using HendonInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HendonInventoryAPI.Services
{
	public class EventService : IEventsRepository
	{
        public HendonDb _context { get; set; }

        public EventService(HendonDb context)
		{
            _context = context;
		}

        public IEnumerable<Event> GetEvents()
        {
            List<Event> events = _context.Events.ToList();
            return events;
        }

        public IEnumerable<EquipmentInUse> GetEquipmentsInUse()
        {
            List<EquipmentInUse> equipmentsInUse = _context.EquipmentIns.ToList();
            return equipmentsInUse;
        }

        
    }
}

