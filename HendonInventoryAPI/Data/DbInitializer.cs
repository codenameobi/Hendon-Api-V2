using System;
using HendonInventoryAPI.Models;

namespace HendonInventoryAPI.Data
{
	public static class DbInitializer
	{
        public static void Initialize(HendonDb context)
        {
            context.Database.EnsureCreated();

            // Look for any events.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            var events  = new Event[]
            {
            new Event{EventName="Carson's event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="Ben's event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="frank's event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="sara's event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="Jim's Event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="danny's event",EventTime=DateTime.Parse("2005-09-01")},
            new Event{EventName="Rave",EventTime=DateTime.Parse("2005-09-01")},
            };

            context.Events.AddRange(events);
            context.SaveChanges();

            var equipments = new Equipment[]
            {
            new Equipment{EquipmentID=1050,EquipmentName="Chemistry",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=4022,EquipmentName="Chemistry2",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=4041,EquipmentName="Chemistry3",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1045,EquipmentName="light",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=3141,EquipmentName="table",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=2021,EquipmentName="chair",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=2022,EquipmentName="post",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            };

            context.Equipments.AddRange(equipments);
            context.SaveChanges();

            var enrollments = new EquipmentInUse[]
            {
                new EquipmentInUse{EventID=1,EquipmentID=1050,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=1,EquipmentID=4022,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=1,EquipmentID=4041,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=2,EquipmentID=1045,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=2,EquipmentID=3141,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=2,EquipmentID=2021,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=3,EquipmentID=4022,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=4,EquipmentID=2022,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=5,EquipmentID=3141,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=6,EquipmentID=2021,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=7,EquipmentID=1050,EquipmentStatus =EquipmentStatus.Missing},
            };
            context.EquipmentIns.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

