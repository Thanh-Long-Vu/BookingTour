using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Model
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int bill_id { get; set; }
        public int product_id { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string status { get; set; }
        public int price { get; set; }
    }
}