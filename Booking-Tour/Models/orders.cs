using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class orders
    {
        [Key]
        public int id { get; set; }

        public bills bill { get; set; }

        public products product { get; set; }

        [StringLength(30), Required]
        public string name { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public int price { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}