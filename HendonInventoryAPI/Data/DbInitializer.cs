using System;
using HendonInventoryAPI.Models;

namespace HendonInventoryAPI.Data
{
	public static class DbInitializer
	{
        public static void Initialize(HendonDb context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
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
            new Equipment{EquipmentID=1052,EquipmentName="Chemistry2",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1053,EquipmentName="Chemistry3",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1054,EquipmentName="light",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1055,EquipmentName="table",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1056,EquipmentName="chair",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            new Equipment{EquipmentID=1057,EquipmentName="post",Description="workimg pro",ImagePath="wrrefcf", CreatedAt=DateTime.Parse("2022-06-20")},
            };

            context.Equipments.AddRange(equipments);
            context.SaveChanges();

            var enrollments = new EquipmentInUse[]
            {
                new EquipmentInUse{EventID=1,EquipmentID=1050,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=1,EquipmentID=1052,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=1,EquipmentID=1053,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=2,EquipmentID=1053,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=2,EquipmentID=1054,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=2,EquipmentID=1057,EquipmentStatus =EquipmentStatus.Occuiped},
                new EquipmentInUse{EventID=3,EquipmentID=1056,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=4,EquipmentID=1055,EquipmentStatus =EquipmentStatus.Missing},
                new EquipmentInUse{EventID=5,EquipmentID=1052,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=6,EquipmentID=1054,EquipmentStatus =EquipmentStatus.Packed},
                new EquipmentInUse{EventID=7,EquipmentID=1051,EquipmentStatus =EquipmentStatus.Missing},
            };
            context.EquipmentIns.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

