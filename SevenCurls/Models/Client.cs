using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevenCurls.Models
{
    public class Client
    {
            
        public Client()
        {
            this._Appointments = new HashSet<Appointment>();
        }
        public int ClientID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Appointment> _Appointments {get; set;}
    }
}