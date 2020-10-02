using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class image_products
    {
        [Key]
        public int id { get; set; }
        [MaxLength(255), Required]
        public string url { get; set; }
        public products product { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}