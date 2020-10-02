using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class product_types
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public ICollection<products> products { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}