using System;
using HendonInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HendonInventoryAPI.Data
{
	public class HendonDb : DbContext
	{
		public HendonDb(DbContextOptions<HendonDb> options) : base(options)
		{
		}

        public DbSet<Event> Events { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentInUse> EquipmentIns { get; set; }

    }
}

