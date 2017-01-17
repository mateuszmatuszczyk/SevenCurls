using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SevenCurls.Models
{
    public class ScheduleModelContext : DbContext
    {
        public ScheduleModelContext() : base("ScheduleModelContext")
        {

        }

        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Staff> StaffList { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Client> Clients { get; set; }
    } 
}
