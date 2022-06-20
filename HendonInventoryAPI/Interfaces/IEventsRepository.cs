using System;
using HendonInventoryAPI.Models;

namespace HendonInventoryAPI.Interfaces
{
	public interface IEventsRepository
	{
		IEnumerable<Event> GetEvents();
		IEnumerable<EquipmentInUse> GetEquipmentsInUse();
	}
}

