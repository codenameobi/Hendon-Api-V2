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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<EquipmentInUse>().ToTable("EquipmentInUse");
            modelBuilder.Entity<Event>().ToTable("Event");

            modelBuilder.Entity<EquipmentInUse>()
            .HasKey(b => b.ItemID);

            modelBuilder.Entity<EquipmentInUse>()
                .HasOne(p => p.Event)
                .WithMany(b => b.EquipmentIns)
                .HasForeignKey(p => p.EventID);

            modelBuilder.Entity<EquipmentInUse>()
                .HasOne(e => e.Equipment)
                .WithMany(b => b.EquipmentIns)
                .HasForeignKey(p => p.EquipmentID);

            //modelBuilder.Entity<Event>().HasData(new Event { EventID = 9, EventName = "Carson's event", EventTime = DateTime.Parse("2005-09-01") });
            //modelBuilder.Entity<EquipmentInUse>().HasData(
            //    new EquipmentInUse { ItemID= 13, EventID = 1, EquipmentID = 1250, EquipmentStatus = EquipmentStatus.Missing });
        }


    }
}

