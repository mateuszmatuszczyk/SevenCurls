using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevenCurls.Models
{
    public class Appointment
    {
             
        public Appointment()
        {
            this._Treatments = new HashSet<Treatment>();
        }
        public int AppointmentID { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public int duration { get; set; }
        public int StaffID { get; set; }
        public int ClientID { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Treatment> _Treatments { get; set; }
    }
}