using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class uti_pro
    {
        [Key]
        public int id { get; set; }

        public products products { get; set; }

        public utilities utilities { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}