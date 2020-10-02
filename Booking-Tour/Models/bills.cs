using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class bills
    {
        [Key]
        public int id { get; set; }
        public users users { get; set; }
        [StringLength(30), Required]
        public string name { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        public string note { get; set; }
        public int status { get; set; }
        public int payments { get; set; }
        public ICollection<orders> orders { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}