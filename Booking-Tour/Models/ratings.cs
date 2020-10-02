using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class ratings
    {
        [Key]
        public int id { get; set; }

        public categorys categorys { get; set; }

        public users user { get; set; }

        public bills bill { get; set; }

        public int point { get; set; }

        [MaxLength(255), Required]
        public string comments { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}