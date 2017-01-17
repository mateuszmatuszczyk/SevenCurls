using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevenCurls.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public int price { get; set; }
    }
}