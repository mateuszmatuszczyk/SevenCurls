namespace SevenCurls.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using SevenCurls.Models;
    
    internal sealed class Configuration : DbMigrationsConfiguration<SevenCurls.Models.ScheduleModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SevenCurls.Models.ScheduleModelContext context)
        {
            var treatments = new List<Treatment>
            {
                new Treatment {name = "Shaving", duration=15, price=10  },
                new Treatment {name = "Hair Perm", duration=60, price=50  },
                new Treatment {name = "Grooming", duration=15, price=10  },

            };
            treatments.ForEach(t => context.Treatments.AddOrUpdate(treatment => treatment.name, t));
            context.SaveChanges();

           

            var salons = new List<Salon>
            {
                new Salon {SalonID=1, Name="Crazy Curls", Street = "123 Main St", City ="Galway"},
                new Salon {SalonID=2, Name="Amazing Highlights", Street = "11 Drive Rd", City ="Limerick"},
                new Salon {SalonID=3, Name="Tricky Haircuts", Street = "1 Monte Casino St", City ="Dublin"},
            };
            salons.ForEach(s => context.Salons.AddOrUpdate(salon => salon.Name, s));
            context.SaveChanges();

            var staffList = new List<Staff>
            {
                new Staff {StaffID = 5, SalonID = 1, Fname = "Maria", Sname ="Smith", Bio = "Maria specialises in highlights and man cuts."},
                new Staff {StaffID = 6, SalonID = 2, Fname = "James", Sname ="McDonald", Bio = "James is a renowned stylist with 10 years experience!"},
                new Staff {StaffID = 7, SalonID = 3, Fname = "Adam", Sname ="Jones", Bio = "Adam specialises in head massaging."},
            };
            staffList.ForEach(sl => context.StaffList.AddOrUpdate(staff => staff.StaffID, sl));
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
