﻿using System;
namespace HendonInventoryAPI.Models
{
    public enum EquipmentStatus
    {
        Missing, Packed, Occuiped
    }

    public class EquipmentInUse
	{
        public int ID { get; set; }
        public int EquipmentID { get; set; }
        public int EventID { get; set; }
        public EquipmentStatus? EquipmentStatus { get; set; }

        public Equipment Equipment { get; set; }
        public Event Event { get; set; }
    }
}

