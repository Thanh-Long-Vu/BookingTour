using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class provinces
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string ma_tp { get; set; }
        public region region { get; set; }
    }
}