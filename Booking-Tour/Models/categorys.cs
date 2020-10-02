using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class categorys
    {
        [Key]
        public int id { get; set; }
        [StringLength(30), Required]
        public string name { get; set; }
        [MaxLength(255), Required]
        public string avatar { get; set; }
        public int status { get; set; }
        public users user { get; set; }
        public region region { get; set; }

        [MaxLength(255), Required]
        public string description { get; set; }
        public int point { get; set; }
        public ICollection<products> products { get; set; }
        public ICollection<ratings> ratings { get; set; }

        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}