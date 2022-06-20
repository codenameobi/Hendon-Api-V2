using System;
namespace HendonInventoryAPI.Models
{
	public class Equipment
	{
		public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

