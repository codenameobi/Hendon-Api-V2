using System;
namespace HendonInventoryAPI.Models
{
	public class Event
	{
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }

        public ICollection<EquipmentInUse> EquipmentIns { get; set; }
    }
}

