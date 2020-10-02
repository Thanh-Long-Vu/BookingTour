using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [StringLength(40), Required, MinLength(5)]
        public string name { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string avatar { get; set; }
        public string phone { get; set; }
    }
}