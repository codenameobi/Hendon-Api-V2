using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HendonInventoryAPI.Models
{
	public class Equipment
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<EquipmentInUse> EquipmentIns { get; set; }
    }
}

