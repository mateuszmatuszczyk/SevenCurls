using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevenCurls.Models
{
    public class Salon
    {
        public Salon()
        {
            this._StaffList = new HashSet<Staff>();
        }
        public int SalonID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual ICollection<Staff> _StaffList { get; set; }
    }
}