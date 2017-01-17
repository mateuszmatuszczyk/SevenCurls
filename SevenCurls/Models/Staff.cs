using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevenCurls.Models
{
    public class Staff
    {
        public Staff()
        {
            this._Appointments = new HashSet<Appointment>();
        }
        
        public int StaffID { get; set; }
        public int SalonID { get; set; }
        public string Fname { get; set; }
        public string Sname { get;set; }
        public string Bio { get; set; }
        public bool Availability { get; set; }

        public virtual Salon Salon { get; set; }
        public virtual ICollection<Appointment> _Appointments { get; set; }
    }
}